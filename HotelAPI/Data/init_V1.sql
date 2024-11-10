CREATE DATABASE hotel_db;

CREATE SCHEMA IF NOT EXISTS core;

SET search_path = "core";

CREATE DOMAIN CARDNUMBER AS VARCHAR(16)
CHECK (VALUE ~ '^[0-9]{16}$');

CREATE DOMAIN CARDDATE AS VARCHAR(5)
CHECK (VALUE ~ '^(0[1-9]|1[0-2])/[0-9]{2}$');

CREATE DOMAIN NAME AS VARCHAR(30)
CHECK (VALUE ~ '^[A-Za-zР-пр-џ]+$');

CREATE DOMAIN EMAIL AS VARCHAR(50)
CHECK (VALUE ~ '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$');

CREATE DOMAIN PHONE AS VARCHAR(12)
CHECK (VALUE ~ '^\+[0-9]{11}$');

CREATE DOMAIN PASSPORT AS VARCHAR(10)
CHECK (VALUE ~ '^[0-9]{10}$');

CREATE TABLE IF NOT EXISTS core.card (
    id SERIAL PRIMARY KEY,
    name NAME NOT NULL UNIQUE,
    number CARDNUMBER NOT NULL UNIQUE,
    date CARDDATE NOT NULL
);

CREATE TABLE IF NOT EXISTS core.role (
    id SERIAL PRIMARY KEY,
    name NAME NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS core.user_account (
    id SERIAL PRIMARY KEY,
    first_name NAME NOT NULL,
    last_name NAME NOT NULL,
    surname NAME,
    email EMAIL NOT NULL UNIQUE,
    phone_number PHONE NOT NULL UNIQUE,
    password VARCHAR(50) NOT NULL CHECK (password >= 10 AND password <= 50),
    passport PASSPORT NOT NULL UNIQUE,
    card_id INT,
    FOREIGN KEY (card_id) REFERENCES core.card (id) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.user_role (
    user_id INT NOT NULL,
    role_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES core.user_account (id),
    FOREIGN KEY (role_id) REFERENCES core.role (id)
);

CREATE TABLE IF NOT EXISTS core.hotel_type (
    id SERIAL PRIMARY KEY,
    name NAME NOT NULL UNIQUE,
    description TEXT
);

CREATE TABLE IF NOT EXISTS core.hotel (
    id SERIAL PRIMARY KEY,
    name NAME NOT NULL UNIQUE,
    city NAME NOT NULL,
    address NAME NOT NULL UNIQUE,
    description TEXT,
    phone_number PHONE NOT NULL UNIQUE,
    email EMAIL NOT NULL UNIQUE,
    construction_year DATE,
    rating INT CHECK (rating >= 1 and rating <= 5),
    manager_id INT NOT NULL,
    hotel_type_id INT NOT NULL,
    FOREIGN KEY (manager_id) REFERENCES core.user_account(id) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE,
    FOREIGN KEY (hotel_type_id) REFERENCES core.hotel_type(id) 
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.room (
    id SERIAL PRIMARY KEY,
    room_type VARCHAR(30) NOT NULL,
    room_number INT NOT NULL CHECK (room_number > 0) UNIQUE,
    capacity INT NOT NULL CHECK (capacity > 0),
    description TEXT,
    price DECIMAL NOT NULL CHECK (price > 0.0),
    hotel_id INT NOT NULL,
    FOREIGN KEY (hotel_id) REFERENCES core.hotel(id)
        ON DELETE RESTRICT
);

CREATE TABLE IF NOT EXISTS core.booking (
    id SERIAL PRIMARY KEY,
    check_in DATE NOT NULL,
    check_out DATE NOT NULL,
    actual_price DECIMAL NOT NULL CHECK (actual_price > 0.0),
    user_account_id INT NOT NULL,
    room_id INT NOT NULL,
    FOREIGN KEY (user_account_id) REFERENCES core.user_account(id) 
        ON DELETE RESTRICT
        ON UPDATE CASCADE,
    FOREIGN KEY (room_id) REFERENCES core.room(id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE  
);

CREATE TABLE IF NOT EXISTS core.payment_room (
    id SERIAL PRIMARY KEY,
    price INT NOT NULL,
    payment_status VARCHAR(30) NOT NULL,
    payment_date DATE NOT NULL,
    booking_id INT NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES core.booking(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.hotel_review (
    id SERIAL PRIMARY KEY,
    comment TEXT NOT NULL,
    publish_date DATE NOT NULL,
    rating INT NOT NULL CHECK (rating >= 1 AND rating <= 5),
    hotel_id INT NOT NULL,
    user_account_id INT NOT NULL,
    FOREIGN KEY (hotel_id) REFERENCES core.hotel(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (user_account_id) REFERENCES core.user_account(id)
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.service (
    id SERIAL PRIMARY KEY,
    name NAME NOT NULL UNIQUE,
    description TEXT,
    price DECIMAL NOT NULL CHECK (price > 0.0),
    hotel_id INT NOT NULL,
    FOREIGN KEY (hotel_id) REFERENCES core.hotel(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.request_service (
    id SERIAL PRIMARY KEY,
    request_date DATE NOT NULL,
    request_time TIME NOT NULL,
    request_status VARCHAR(30) NOT NULL,
    additional_notes TEXT,
    quantity_requests INT NOT NULL CHECK (quantity_requests > 1),
    service_id INT NOT NULL,
    user_account_id INT NOT NULL,
    FOREIGN KEY (service_id) REFERENCES core.user_account(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (user_account_id) REFERENCES core.user_account(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.request_service_review (
    id SERIAL PRIMARY KEY,
    comment TEXT NOT NULL,
    publish_date DATE NOT NULL,
    rating INT NOT NULL CHECK (rating >= 1 AND rating <= 5),
    request_service_id INT NOT NULL,
    user_account_id INT NOT NULL,
    FOREIGN KEY (request_service_id) REFERENCES core.request_service(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (user_account_id) REFERENCES core.user_account(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.comfort (
    id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL UNIQUE,
    description TEXT
);

CREATE TABLE IF NOT EXISTS core.room_comfort (
    room_id INT NOT NULL,
    comfort_id INT NOT NULL,
    FOREIGN KEY (room_id) REFERENCES core.room(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (comfort_id) REFERENCES core.comfort(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE 
);

CREATE TABLE IF NOT EXISTS core.travel (
    id SERIAL PRIMARY KEY,
    name NAME NOT NULL UNIQUE,
    description TEXT,
    price DECIMAL NOT NULL CHECK (price > 0.0),
    departure_date DATE NOT NULL,
    arrival_date DATE NOT NULL,
    hotel_id INT NOT NULL,
    FOREIGN KEY (hotel_id) REFERENCES core.hotel(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.payment_travel (
    id SERIAL PRIMARY KEY,
    price INT NOT NULL,
    payment_status VARCHAR(30) NOT NULL,
    payment_date DATE NOT NULL,
    travel_id INT NOT NULL,
    user_account_id INT NOT NULL,
    FOREIGN KEY (travel_id) REFERENCES core.travel(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (user_account_id) REFERENCES core.user_account(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS core.travel_review (
    id SERIAL PRIMARY KEY,
    comment TEXT NOT NULL,
    publish_date DATE NOT NULL,
    travel_id INT NOT NULL,
    rating INT NOT NULL CHECK (rating >= 1 and rating <= 5),
    user_account_id INT NOT NULL,
    FOREIGN KEY (travel_id) REFERENCES core.travel(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (user_account_id) REFERENCES core.user_account(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE ROLE client WITH LOGIN PASSWORD 'clientpass';

GRANT CONNECT ON DATABASE hotel_db TO client;
GRANT USAGE ON SCHEMA core TO client;

GRANT SELECT ON TABLE core.hotel TO client;
GRANT SELECT ON TABLE core.room TO client;
GRANT SELECT, INSERT ON TABLE core.hotel_review TO client;
GRANT SELECT, INSERT ON TABLE core.request_service_review TO client;
GRANT SELECT, SELECT ON TABLE core.travel_review TO client;
GRANT SELECT ON TABLE core.comfort TO client;
GRANT SELECT ON TABLE core.room_comfort TO client;

CREATE ROLE administrator WITH LOGIN PASSWORD 'rootpass';
GRANT CONNECT ON DATABASE hotel_db TO administrator;
GRANT USAGE ON SCHEMA core, public TO administrator;

GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA core, public TO administrator;
GRANT CREATE ON SCHEMA core, public;
ALTER DEFAULT PRIVILEGES IN SCHEMA core, public GRANT ALL PRIVILEGES ON TABLES TO administrator;
ALTER DEFAULT PRIVILEGES IN SCHEMA core, public GRANT ALL PRIVILEGES ON SEQUENCES TO administrator;

ALTER TABLE core.comfort
ALTER COLUMN name TYPE NAME;

ALTER TABLE core.user_account
ADD CONSTRAINT password_length_check
CHECK (length(password) >= 10 AND length(password) <= 50);

ALTER TABLE core.payment_room
ALTER COLUMN price TYPE DECIMAL;

ALTER TABLE core.payment_room
ADD CONSTRAINT price_range_check
CHECK (price BETWEEN 0 and 10000000);