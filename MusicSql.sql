CREATE TABLE "Bands" (
  "Name"   TEXT NOT NULL,
    "ContactName"  TEXT,
  "Genre"  TEXT,
  "CountryOfOrigin"  TEXT,
  "Website"  TEXT,
  "NumberOfMembers"  INT,
  "IsSigned" BOOLEAN,
  "Id" SERIAL PRIMARY KEY
);
-- insert tables for Bands
INSERT INTO "Bands" ("Name", "ContactName", "Genre", "CountryOfOrrgin", "Website", "NumberOfMembers", "IsSigned")
VALUES ('WhiteSnake', Chuck, 'Rock', 'USA', 'www.rock.com', 4, TRUE);
INSERT INTO "Bands" ("Name", "ContactName", "Genre", "CountryOfOrrgin", "Website", "NumberOfMembers", "IsSigned")
VALUES ('Twisted Sister', Chuck, 'Rock', 'USA', 'www.rock.com', 4, TRUE);
INSERT INTO "Bands" ("Name", "ContactName", "Genre", "CountryOfOrrgin", "Website", "NumberOfMembers", "IsSigned")
VALUES ('ACDC', Chuck, 'Rock', 'USA', 'www.rock.com', 3, FALSE);
INSERT INTO "Bands" ("Name", "ContactName", "Genre", "CountryOfOrrgin", "Website", "NumberOfMembers", "IsSigned")
VALUES ('Beastie Boys', Chuck, 'Rap', 'USA', 'www.rap.com', 3, TRUE);
INSERT INTO "Bands" ("Name", "ContactName", "Genre", "CountryOfOrrgin", "Website", "NumberOfMembers", "IsSigned")
VALUES ('Run DMC', Chuck, 'Rap', 'USA', 'www.rap.com', 4, TRUE);

CREATE TABLE "Albums" (
  "Title"   TEXT NOT NULL,
  "IsExplicit" BOOLEAN,
  "ReleaseDate"     DATE,
  "BandId" INTEGER REFERENCES "Bands" ("Id"),
  "Id" SERIAL PRIMARY KEY
);
--insert tables for Albums
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Cobra', TRUE, '12/30/1980', 1);
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Viper', TRUE, '12/30/1982', 1);
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Family', TRUE, '12/30/1981', 2);
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Party', TRUE, '12/30/1986', 2);
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Freedom', FALSE, '12/30/1991', 3);
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Ill Communication', TRUE, '12/30/1986', 4);
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Intergalactice', TRUE, '12/30/1990', 4);
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Walk this way', TRUE, '12/30/1983', 5);
INSERT INTO "Albums" ("Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES ('Talk this way', TRUE, '12/30/1992', 5);

CREATE TABLE "Songs" (
  "SongTitle"   TEXT NOT NULL,
  "TrackNumber"  INT,
  "Duration"  TIME,
  "AlbumId" INTEGER REFERENCES "Albums" ("Id"),
  "Id" SERIAL PRIMARY KEY
);
--insert tables for Songs
--Song on cobra/whitesnake 11
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Cobra', 1, '02:32', 1);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Cobra Strick', 2, '03:32', 1);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Cobra love', 3, '04:32', 1);

--songs on viper/whitesnake 21
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Viper', 1, '06:32', 2);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Viper Harder', 2, '02:32', 2);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Viper Fastest', 3, '04:32', 2);

-- Songs on Family/Twisted Sister 32
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Momma', 1, '06:33', 3);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Sister', 2, '07:31', 3);

-- Songs on party/Twisted Sister 42
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Party', 1, '06:32', 4);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Party Harder', 2, '09:32', 4);

--Songs on Freedom/ACDC 53
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Constitution', 1, '02:32', 5);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Amendment', 2, '06:52', 5);

--Songs on Ill Communication/Beastie Boys 64
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Brass Monkey', 1, '16:32', 6);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Funky Monkey', 2, '06:32', 6);

--Songs on Intergalactice/Beastie Boys 74
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Space', 1, '06:32', 7);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Planetary', 2, '06:32', 7);

--Songs on Walk this way/Run DMC 85
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Walk', 1, '04:32', 8);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Need', 2, '03:32', 8);

--Songs on Talk this way/Run DMC 95
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Talk', 1, '05:32', 9);
INSERT INTO "Songs" ("SongTitle", "TrackNumber", "Duration", "AlbumId")
VALUES ('Want', 2, '06:39', 9);

CREATE TABLE "Musicians" (
  "FullName"   TEXT NOT NULL,
  "Position"  TEXT,
  "Id" SERIAL PRIMARY KEY
);

-- Musicians to insert... unsure if i need to add a bandid to musisians 
INSERT INTO "Musicians" ("FullName", "Position")
VALUES ('Roger', 'Singer');
INSERT INTO "Musicians" ("FullName", "Position")
VALUES ('Steve', 'Singer');
INSERT INTO "Musicians" ("FullName", "Position")
VALUES ('John', 'Singer');
INSERT INTO "Musicians" ("FullName", "Position")
VALUES ('Clarence', 'Singer');
INSERT INTO "Musicians" ("FullName", "Position")
VALUES ('Ad Rock', 'Singer');
INSERT INTO "Musicians" ("FullName", "Position")
VALUES ('MCA', 'Singer');
INSERT INTO "Musicians" ("FullName", "Position")
VALUES ('Spock', 'Singer');

-- Musicians is a many to many relationship with Bands
--insert tables for Musicians
INSERT INTO "Musicians" ("FullName", "Position")
VALUES ('Roger', 'Singer');

CREATE TABLE "BandMembers" (
  "MusicianId" INTEGER REFERENCES "Musicians" ("Id"),
  "BandId" INTEGER REFERENCES "Bands" ("Id"),
);
--This is the join table for Musicians and bannds 
