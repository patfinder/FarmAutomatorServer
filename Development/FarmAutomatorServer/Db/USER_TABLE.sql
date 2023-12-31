--------------------------------------------------------
--  DDL for Table USER_TABLE
--------------------------------------------------------

  CREATE TABLE "FARM_DB"."USER_TABLE" 
   (	"USER_NO" VARCHAR2(20 BYTE), 
	"USER_NAME" VARCHAR2(20 BYTE), 
	"PASSWORD" VARCHAR2(20 BYTE), 
	"USER_VNAME" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into FARM_DB.USER_TABLE
SET DEFINE OFF;
Insert into FARM_DB.USER_TABLE (USER_NO,USER_NAME,PASSWORD,USER_VNAME) values ('uid_1','User 1','password','user vname 1');
Insert into FARM_DB.USER_TABLE (USER_NO,USER_NAME,PASSWORD,USER_VNAME) values ('uid_2','User 2','password','user vname 2');
