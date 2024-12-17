DO $$ 
BEGIN
    IF NOT EXISTS (SELECT FROM pg_tables WHERE tablename = 'FlightSchedules') THEN
        CREATE TABLE "FlightSchedules" (
            "FlightId" VARCHAR(10) PRIMARY KEY,
            "DepartureCity" VARCHAR(50) NOT NULL,
            "ArrivalCity" VARCHAR(50) NOT NULL,
            "DepartureTime" TIMESTAMP NOT NULL,
            "ArrivalTime" TIMESTAMP NOT NULL,
            CONSTRAINT valid_times CHECK ("ArrivalTime" > "DepartureTime")
        );
    END IF;
END
$$
;

TRUNCATE TABLE "FlightSchedules";

INSERT INTO "FlightSchedules" ("FlightId", "DepartureCity", "ArrivalCity", "DepartureTime", "ArrivalTime") VALUES 
('FL001', 'Phoenix', 'Los Angeles', '2024-01-01 06:03:00', '2024-01-01 07:06:00'),
('FL020', 'New York', 'Phoenix', '2024-01-01 22:45:00', '2024-01-02 02:30:00');
