-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Nov 26. 22:11
-- Kiszolgáló verziója: 10.4.25-MariaDB
-- PHP verzió: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `pastalavista`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `feltetek`
--

CREATE TABLE `feltetek` (
  `feltetid` int(10) NOT NULL,
  `nev` varchar(100) COLLATE utf32_hungarian_ci NOT NULL,
  `ar` varchar(100) COLLATE utf32_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_hungarian_ci;

--
-- A tábla adatainak kiíratása `feltetek`
--

INSERT INTO `feltetek` (`feltetid`, `nev`, `ar`) VALUES
(1, 'paradicsomos alap', '100'),
(2, 'tejfölös alap', '150'),
(3, 'fokhagymás-tejfölös alap', '75'),
(4, 'sajt', '300'),
(5, 'szalámi', '235'),
(6, 'ananász', '140'),
(7, 'kukorica', '80'),
(8, 'borsó', '70'),
(9, 'brokkoli', '340'),
(10, 'füstölt trappista', '220'),
(11, 'füstölt mozzarella', '230'),
(12, 'paradicsomkarika', '75'),
(13, 'sonka', '125'),
(14, 'olíva', '50'),
(15, 'gomba', '150'),
(16, 'bacon', '320'),
(17, 'mozzarella', '220'),
(18, 'uborka ', '195'),
(19, 'tarja', '210'),
(20, 'tojás', '280');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `fizetes`
--

CREATE TABLE `fizetes` (
  `id` int(10) NOT NULL,
  `fizetestipus` varchar(50) COLLATE utf32_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_hungarian_ci;

--
-- A tábla adatainak kiíratása `fizetes`
--

INSERT INTO `fizetes` (`id`, `fizetestipus`) VALUES
(1, 'készpénz'),
(2, 'bankkártya');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `meret`
--

CREATE TABLE `meret` (
  `meretszam` int(10) NOT NULL,
  `ar` varchar(100) COLLATE utf32_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_hungarian_ci;

--
-- A tábla adatainak kiíratása `meret`
--

INSERT INTO `meret` (`meretszam`, `ar`) VALUES
(22, '1100'),
(28, '1250'),
(32, '1500');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `pizzak`
--

CREATE TABLE `pizzak` (
  `pizzaid` int(10) NOT NULL,
  `nev` varchar(200) COLLATE utf32_hungarian_ci NOT NULL,
  `feltetek_ara` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_hungarian_ci;

--
-- A tábla adatainak kiíratása `pizzak`
--

INSERT INTO `pizzak` (`pizzaid`, `nev`, `feltetek_ara`) VALUES
(1, 'Sajtos', 525),
(2, 'Gombás', 550),
(3, '4 Évszak Vega', 1040),
(4, 'Vega', 1040),
(5, 'Gomba-Olíva', 600),
(6, 'Sonkás-Gombás', 675),
(7, 'Hawaii', 665),
(8, 'Baconos', 1050),
(9, 'Szalámis', 635),
(10, '4 Évszak Hús', 1290),
(11, 'Tarjás', 880),
(12, 'Sonka-Tarja', 735),
(13, '4 sajtos', 1070),
(14, 'Tojásos-Baconos', 975),
(15, 'California', 950);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `pizza_feltet`
--

CREATE TABLE `pizza_feltet` (
  `pizzaid` int(10) NOT NULL,
  `feltetid` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_hungarian_ci;

--
-- A tábla adatainak kiíratása `pizza_feltet`
--

INSERT INTO `pizza_feltet` (`pizzaid`, `feltetid`) VALUES
(1, 1),
(1, 4),
(1, 13),
(2, 1),
(2, 4),
(2, 15),
(3, 1),
(3, 4),
(3, 7),
(3, 8),
(3, 9),
(3, 15),
(4, 1),
(4, 4),
(4, 7),
(4, 8),
(4, 9),
(4, 15),
(5, 1),
(5, 4),
(5, 14),
(5, 15),
(6, 1),
(6, 4),
(6, 13),
(6, 15),
(7, 1),
(7, 4),
(7, 6),
(7, 13),
(8, 2),
(8, 4),
(8, 16),
(8, 20),
(9, 1),
(9, 4),
(9, 5),
(10, 1),
(10, 4),
(10, 5),
(10, 13),
(10, 16),
(10, 19),
(11, 2),
(11, 4),
(11, 17),
(11, 19),
(12, 1),
(12, 4),
(12, 13),
(12, 19),
(13, 1),
(13, 4),
(13, 10),
(13, 11),
(13, 17),
(14, 3),
(14, 4),
(14, 16),
(14, 20),
(15, 2),
(15, 4),
(15, 10),
(15, 20);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendelesek`
--

CREATE TABLE `rendelesek` (
  `rendelesszam` int(10) NOT NULL,
  `ugyfelkod` int(10) DEFAULT NULL,
  `pizzaid` int(10) DEFAULT NULL,
  `meretszam` int(10) DEFAULT NULL,
  `fizetesid` int(10) DEFAULT NULL,
  `osszar` int(100) DEFAULT NULL,
  `fizetve` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_hungarian_ci;

--
-- A tábla adatainak kiíratása `rendelesek`
--

INSERT INTO `rendelesek` (`rendelesszam`, `ugyfelkod`, `pizzaid`, `meretszam`, `fizetesid`, `osszar`, `fizetve`) VALUES
(1000, 4, 5, 32, 1, 2100, 1),
(1001, 5, 8, 28, 1, 2300, 1),
(1002, 5, 8, 32, 2, 2550, 1),
(1003, 3, 5, 32, 2, 2100, 1),
(1004, 11, 1, 32, 1, 2025, 1),
(1005, 20, 11, 22, 1, 1980, 1),
(1006, 20, 10, 22, 2, 2390, 1),
(1007, 18, 6, 22, 1, 1775, 1),
(1008, 6, 15, 28, 2, 2200, 1),
(1009, 6, 6, 28, 1, 1925, 1),
(1010, 28, 1, 32, 1, 2025, 1),
(1011, 19, 5, 32, 2, 2100, 0),
(1012, 2, 3, 22, 1, 2140, 1),
(1013, 23, 14, 32, 2, 2475, 1),
(1014, 7, 10, 32, 2, 2790, 1),
(1015, 10, 7, 28, 1, 1915, 1),
(1016, 13, 9, 28, 2, 1885, 1),
(1017, 14, 13, 22, 1, 2170, 1),
(1018, 24, 6, 22, 1, 1775, 1),
(1019, 26, 9, 32, 2, 2135, 1),
(1020, 29, 12, 22, 2, 1835, 1),
(1021, 28, 5, 22, NULL, 1700, 0),
(1022, 22, 6, 32, NULL, 2175, 0),
(1023, 2, 6, 32, NULL, 2175, 0),
(1024, 4, 10, 32, NULL, 2790, 0),
(1025, 8, 7, 32, NULL, 2165, 0),
(1026, 13, 9, 28, NULL, 1885, 0),
(1027, 14, 13, 28, NULL, 2320, 0),
(1028, 3, 14, 22, NULL, 2075, 0),
(1029, 3, 15, 32, NULL, 2450, 0),
(1030, 5, 9, 22, NULL, 1735, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugyfelek`
--

CREATE TABLE `ugyfelek` (
  `ugyfelkod` int(10) NOT NULL,
  `nev` varchar(200) COLLATE utf32_hungarian_ci NOT NULL,
  `cim` varchar(500) COLLATE utf32_hungarian_ci DEFAULT NULL,
  `telefon` varchar(20) COLLATE utf32_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugyfelek`
--

INSERT INTO `ugyfelek` (`ugyfelkod`, `nev`, `cim`, `telefon`) VALUES
(1, 'Palóc Csaba', 'Szeged, Retek u. 10', '06706644321'),
(2, 'Bekre Pál', 'Szeged, Rét u. 21', '06303558989'),
(3, 'Kocsis Csaba', 'Szeged, Londoni krt. 24', '06206765544'),
(4, 'Bader Paszát', 'Makó Napsugár u. 2', '06702336666'),
(5, 'Németh Panna', 'Klárafalva, Fő u. 1', '06301312311'),
(6, 'Slutyerák Norbert', 'Makó, Csillag u. 45', '06303031122'),
(7, 'Szép Tamara', 'Szeged, Berlini krt. 41', '06209988776'),
(8, 'Kristály József', 'Makó, Pacsirta u. 33', '06701429985'),
(9, 'Horváth Benedek', 'Szeged, Mars tér u. 8', '06204554444'),
(10, 'Sándori Sándor', 'Domaszék, Szék u. 455', '06304577823'),
(11, 'Pető Vanessza', 'Dombó, Palack u. 21', '06201223322'),
(12, 'Kiss Tamás', 'Szeged, Akácos u. 45,', '06305540303'),
(13, 'Áldott Aura', 'Szeged, Béla u. 32', '06904563883'),
(14, 'Git Áron', 'Makó, Bem u. 31', '06904553120'),
(15, 'Dil Emma', 'Makó, Csalán u. 121', '06904552299'),
(16, 'Eszte Lenke', 'Makó, Csiki u. 78', '06304209911'),
(17, 'Szikla Szilárd', 'Domaszék, Dália u. 21', '06708811212'),
(18, 'Bátor Vitéz', 'Domaszék, Dalos u. 3', '06701234567'),
(19, 'Forró Napsugár', 'Algyő, Erdész u. 25', '06309872604'),
(20, 'Gá Zóra', 'Algyő, Estike u. 9', '06309862544'),
(21, 'Kér Ede', 'Kiskunhalas, Fontos u. 33', '06707981165'),
(22, 'Patta Nóra', 'Hódmezővásárhely, Gál u. 2', '06901289332'),
(23, 'Remete János', 'Hódmezővásárhely, Gogol u. 8', '06708885421'),
(24, 'Lakatos Imre', 'Hódmezővásárhely, Hajlat u. 21', '06702239719'),
(25, 'Álmos Rómeo', 'Szeged, Harcsa u. 17', '06906689090'),
(26, 'Napos József', 'Szeged, Káka u. 72', '06302238890'),
(27, 'Stól András', 'Makó, Major u. 35', '06705617898'),
(28, 'Hiszük Endre', 'Kiskunhalas, Olt u. 27', '06302378855'),
(29, 'Friss Manuel', 'Kiskunhalas, Orgona u. 16', '06207895612'),
(30, 'Kedves Aladár', 'Makó, Hagyma u. 14', '06307812466');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `feltetek`
--
ALTER TABLE `feltetek`
  ADD PRIMARY KEY (`feltetid`);

--
-- A tábla indexei `fizetes`
--
ALTER TABLE `fizetes`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `meret`
--
ALTER TABLE `meret`
  ADD PRIMARY KEY (`meretszam`);

--
-- A tábla indexei `pizzak`
--
ALTER TABLE `pizzak`
  ADD PRIMARY KEY (`pizzaid`),
  ADD UNIQUE KEY `pizzaid` (`pizzaid`);

--
-- A tábla indexei `pizza_feltet`
--
ALTER TABLE `pizza_feltet`
  ADD UNIQUE KEY `pizzaid` (`pizzaid`,`feltetid`),
  ADD KEY `feltet.id` (`feltetid`);

--
-- A tábla indexei `rendelesek`
--
ALTER TABLE `rendelesek`
  ADD PRIMARY KEY (`rendelesszam`),
  ADD KEY `pizzaid` (`pizzaid`),
  ADD KEY `ugyfelkod` (`ugyfelkod`) USING BTREE,
  ADD KEY `meretszam` (`meretszam`) USING BTREE,
  ADD KEY `fizetesid` (`fizetesid`) USING BTREE;

--
-- A tábla indexei `ugyfelek`
--
ALTER TABLE `ugyfelek`
  ADD PRIMARY KEY (`ugyfelkod`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `feltetek`
--
ALTER TABLE `feltetek`
  MODIFY `feltetid` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `fizetes`
--
ALTER TABLE `fizetes`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `meret`
--
ALTER TABLE `meret`
  MODIFY `meretszam` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT a táblához `pizzak`
--
ALTER TABLE `pizzak`
  MODIFY `pizzaid` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT a táblához `rendelesek`
--
ALTER TABLE `rendelesek`
  MODIFY `rendelesszam` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1031;

--
-- AUTO_INCREMENT a táblához `ugyfelek`
--
ALTER TABLE `ugyfelek`
  MODIFY `ugyfelkod` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `pizza_feltet`
--
ALTER TABLE `pizza_feltet`
  ADD CONSTRAINT `pizza_feltet_ibfk_1` FOREIGN KEY (`feltetid`) REFERENCES `feltetek` (`feltetid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `pizza_feltet_ibfk_2` FOREIGN KEY (`pizzaid`) REFERENCES `pizzak` (`pizzaid`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `rendelesek`
--
ALTER TABLE `rendelesek`
  ADD CONSTRAINT `rendelesek_ibfk_6` FOREIGN KEY (`ugyfelkod`) REFERENCES `ugyfelek` (`ugyfelkod`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rendelesek_ibfk_7` FOREIGN KEY (`fizetesid`) REFERENCES `fizetes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rendelesek_ibfk_8` FOREIGN KEY (`pizzaid`) REFERENCES `pizzak` (`pizzaid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rendelesek_ibfk_9` FOREIGN KEY (`meretszam`) REFERENCES `meret` (`meretszam`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
