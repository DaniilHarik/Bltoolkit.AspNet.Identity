CREATE TABLE users (
  Id VARCHAR(45) NOT NULL,
  UserName VARCHAR(45) NULL,
  PasswordHash VARCHAR(100) NULL,
  SecurityStamp VARCHAR(45) NULL,
  PRIMARY KEY (id));

CREATE TABLE roles (
  Id VARCHAR(45) NOT NULL,
  Name VARCHAR(45) NULL,
  PRIMARY KEY (Id));

CREATE TABLE userclaims (
  Id INT NOT NULL PRIMARY KEY,
  UserId VARCHAR(45) NULL,
  ClaimType VARCHAR(100) NULL,
  ClaimValue VARCHAR(100) NULL,
  FOREIGN KEY (UserId)
    REFERENCES users (Id) on delete cascade);

CREATE TABLE userlogins (
  UserId VARCHAR(45) NOT NULL,
  ProviderKey VARCHAR(100) NULL,
  LoginProvider VARCHAR(100) NULL,
  FOREIGN KEY (UserId)
    REFERENCES users (Id) on delete cascade);

CREATE TABLE userroles (
  UserId VARCHAR(45) NOT NULL,
  RoleId VARCHAR(45) NOT NULL,
  PRIMARY KEY (UserId, RoleId),
  FOREIGN KEY (UserId)
    REFERENCES users (Id) 
		on delete cascade
		on update cascade,
  FOREIGN KEY (RoleId)
    REFERENCES roles (Id)
		on delete cascade
		on update cascade);
