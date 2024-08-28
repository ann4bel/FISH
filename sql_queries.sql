



-- ALTER DATABASE games SET ENABLE_BROKER;

-- SELECT * FROM games;

-- INSERT INTO games (total_size, size, owner_name) VALUES
-- (6, 3, 'hi');

-- ALTER TABLE games ALTER COLUMN id INT IDENTITY(1,1);

-- ALTER TABLE games
-- ADD PRIMARY KEY (id);

-- ALTER TABLE games
-- ALTER COLUMN id int NOT NULL;

-- CREATE TABLE games 
-- (id INT IDENTITY(1,1) NOT NULL, size INT NOT NULL, total_size INT NOT NULL, 
-- owner_name VARCHAR(255) NOT NULL, PRIMARY KEY (id));

-- print all tables in a database
-- SELECT
--   *
-- FROM
--   INFORMATION_SCHEMA.TABLES;