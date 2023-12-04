--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2 (Debian 15.2-1.pgdg110+1)
-- Dumped by pg_dump version 15.2 (Debian 15.2-1.pgdg110+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: amenity; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.amenity (
    amenityid integer NOT NULL,
    name character varying
);


--
-- Name: amenity_amenityid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.amenity_amenityid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: amenity_amenityid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.amenity_amenityid_seq OWNED BY public.amenity.amenityid;


--
-- Name: roomavailability; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.roomavailability (
    roomid integer,
    hotelid integer,
    date date,
    available boolean
);


--
-- Name: availablerooms; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.availablerooms AS
 SELECT roomavailability.roomid
   FROM public.roomavailability
  WHERE (roomavailability.available = true);


--
-- Name: guest; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.guest (
    guestid integer NOT NULL,
    name character varying,
    email character varying,
    phone bigint
);


--
-- Name: guest_guestid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.guest_guestid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: guest_guestid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.guest_guestid_seq OWNED BY public.guest.guestid;


--
-- Name: hotel; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.hotel (
    hotelid integer NOT NULL,
    name character varying,
    phone bigint,
    address character varying
);


--
-- Name: hotel_hotelid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.hotel_hotelid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: hotel_hotelid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.hotel_hotelid_seq OWNED BY public.hotel.hotelid;


--
-- Name: hoteltopoi; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.hoteltopoi (
    hotelid integer,
    poid integer
);


--
-- Name: pointofinterest; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.pointofinterest (
    poid integer NOT NULL,
    name character varying,
    description text
);


--
-- Name: pointofinterest_poid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.pointofinterest_poid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: pointofinterest_poid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.pointofinterest_poid_seq OWNED BY public.pointofinterest.poid;


--
-- Name: reservation; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.reservation (
    guestid integer,
    roomid integer,
    startdate date,
    enddate date,
    confirmnumber integer
);


--
-- Name: room; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.room (
    roomid integer NOT NULL,
    hotelid integer,
    roomnumber integer NOT NULL,
    rate numeric
);


--
-- Name: room_roomid_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.room_roomid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: room_roomid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.room_roomid_seq OWNED BY public.room.roomid;


--
-- Name: room_roomnumber_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.room_roomnumber_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: room_roomnumber_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.room_roomnumber_seq OWNED BY public.room.roomnumber;


--
-- Name: roomtoamenity; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.roomtoamenity (
    roomid integer,
    amenityid integer
);


--
-- Name: view_guest; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.view_guest AS
 SELECT guest.name AS guest_name
   FROM public.guest;


--
-- Name: amenity amenityid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.amenity ALTER COLUMN amenityid SET DEFAULT nextval('public.amenity_amenityid_seq'::regclass);


--
-- Name: guest guestid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.guest ALTER COLUMN guestid SET DEFAULT nextval('public.guest_guestid_seq'::regclass);


--
-- Name: hotel hotelid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.hotel ALTER COLUMN hotelid SET DEFAULT nextval('public.hotel_hotelid_seq'::regclass);


--
-- Name: pointofinterest poid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.pointofinterest ALTER COLUMN poid SET DEFAULT nextval('public.pointofinterest_poid_seq'::regclass);


--
-- Name: room roomid; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.room ALTER COLUMN roomid SET DEFAULT nextval('public.room_roomid_seq'::regclass);


--
-- Name: room roomnumber; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.room ALTER COLUMN roomnumber SET DEFAULT nextval('public.room_roomnumber_seq'::regclass);


--
-- Name: amenity amenity_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.amenity
    ADD CONSTRAINT amenity_pkey PRIMARY KEY (amenityid);


--
-- Name: guest guest_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.guest
    ADD CONSTRAINT guest_pkey PRIMARY KEY (guestid);


--
-- Name: hotel hotel_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.hotel
    ADD CONSTRAINT hotel_pkey PRIMARY KEY (hotelid);


--
-- Name: pointofinterest pointofinterest_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.pointofinterest
    ADD CONSTRAINT pointofinterest_pkey PRIMARY KEY (poid);


--
-- Name: room room_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT room_pkey PRIMARY KEY (roomid);


--
-- Name: roomtoamenity fk_amenity; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.roomtoamenity
    ADD CONSTRAINT fk_amenity FOREIGN KEY (amenityid) REFERENCES public.amenity(amenityid);


--
-- Name: reservation fk_guest; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.reservation
    ADD CONSTRAINT fk_guest FOREIGN KEY (guestid) REFERENCES public.guest(guestid);


--
-- Name: room fk_hotel; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT fk_hotel FOREIGN KEY (hotelid) REFERENCES public.hotel(hotelid);


--
-- Name: roomavailability fk_hotel; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.roomavailability
    ADD CONSTRAINT fk_hotel FOREIGN KEY (hotelid) REFERENCES public.hotel(hotelid);


--
-- Name: hoteltopoi fk_hotel; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.hoteltopoi
    ADD CONSTRAINT fk_hotel FOREIGN KEY (hotelid) REFERENCES public.hotel(hotelid);


--
-- Name: hoteltopoi fk_poi; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.hoteltopoi
    ADD CONSTRAINT fk_poi FOREIGN KEY (poid) REFERENCES public.pointofinterest(poid);


--
-- Name: roomavailability fk_room; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.roomavailability
    ADD CONSTRAINT fk_room FOREIGN KEY (roomid) REFERENCES public.room(roomid);


--
-- Name: reservation fk_room; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.reservation
    ADD CONSTRAINT fk_room FOREIGN KEY (roomid) REFERENCES public.room(roomid);


--
-- Name: roomtoamenity fk_room; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.roomtoamenity
    ADD CONSTRAINT fk_room FOREIGN KEY (roomid) REFERENCES public.room(roomid);


--
-- PostgreSQL database dump complete
--

