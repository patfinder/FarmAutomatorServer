--------------------------------------------------------
--  DDL for Table ACTION_TABLE
--------------------------------------------------------

  CREATE TABLE "FARM_DB"."ACTION_TABLE" 
   (	"ID_ACTION" VARCHAR2(20 BYTE), 
	"BIG_CODE" VARCHAR2(20 BYTE), 
	"MEDIUM_CODE" VARCHAR2(20 BYTE), 
	"USER_NO" VARCHAR2(20 BYTE), 
	"TIME" TIMESTAMP (6), 
	"QUANTITY" NUMBER
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
REM INSERTING into FARM_DB.ACTION_TABLE
SET DEFINE OFF;
--------------------------------------------------------
--  Constraints for Table ACTION_TABLE
--------------------------------------------------------

  ALTER TABLE "FARM_DB"."ACTION_TABLE" MODIFY ("USER_NO" NOT NULL ENABLE);
