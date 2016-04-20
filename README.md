# nTiered
N-Tiered C# web application.


DB used was MySQL, you can recreate the DB I used as a test with:

CREATE TABLE `edata` (
  `emID` int(11) NOT NULL AUTO_INCREMENT,
  `address` varchar(255) DEFAULT NULL,
  `salary` varchar(255) DEFAULT NULL,
  `dept` varchar(255) DEFAULT NULL,
  `supervisor` varchar(255) DEFAULT NULL,
  `tenure` varchar(255) DEFAULT NULL,
  `lastName` varchar(255) DEFAULT NULL,
  `firstName` varchar(255) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `city` varchar(255) DEFAULT NULL,
  `region` varchar(255) DEFAULT NULL,
  `postalCode` varchar(255) DEFAULT NULL,
  `country` varchar(255) DEFAULT NULL,
  `extension` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`emID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
