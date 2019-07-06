Database Creation (Run this script First!):

CREATE SCHEMA `articleapi` DEFAULT CHARACTER SET utf8 COLLATE utf8_turkish_ci ;


Table Creations(Run this script after Database Creation!):

USE `articleapi`;

CREATE TABLE `Authors` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(250) NOT NULL,
    `Bio` longtext NULL,
    CONSTRAINT `PK_Authors` PRIMARY KEY (`Id`)
);

CREATE TABLE `Articles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(250) NOT NULL,
    `Content` longtext NULL,
    `AuthorId` int NOT NULL,
    CONSTRAINT `PK_Articles` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Articles_Authors_AuthorId` FOREIGN KEY (`AuthorId`) REFERENCES `Authors` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_Articles_AuthorId` ON `Articles` (`AuthorId`);
