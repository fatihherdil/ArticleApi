CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

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

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190706173530_InitialCreate', '2.2.4-servicing-10062');

