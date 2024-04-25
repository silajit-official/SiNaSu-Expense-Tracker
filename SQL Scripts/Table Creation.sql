CREATE DATABASE EXP_TRACKER
USE EXP_TRACKER

CREATE TABLE CUSTOMER(CUST_ID BIGINT IDENTITY(1,1),CUST_FNAME VARCHAR(20),CUST_LNAME VARCHAR(20),CUST_EMAIL VARCHAR(50),[CUST_PASSWORD] VARCHAR(50),CUST_IMAGE_URL VARCHAR(100))
ALTER TABLE CUSTOMER ADD CONSTRAINT PK_CUSTOMER PRIMARY KEY (CUST_ID)

CREATE TABLE EXPENSE_CATEGORY(EC_ID BIGINT IDENTITY(1,1), EC_EXPENSE_NAME VARCHAR(100))
ALTER TABLE EXPENSE_CATEGORY ADD CONSTRAINT PK_EXPENSE_CATEGORY PRIMARY KEY (EC_ID)

CREATE TABLE CUSTOMER_EXPENSE(CE_ID BIGINT IDENTITY(1,1), CE_CUST_ID BIGINT,CE_EC_ID BIGINT)
ALTER TABLE CUSTOMER_EXPENSE ADD CONSTRAINT PK_CUSTOMER_EXPENSE PRIMARY KEY (CE_ID)
ALTER TABLE CUSTOMER_EXPENSE ADD CONSTRAINT FK_CUSTOMER FOREIGN KEY (CE_CUST_ID) REFERENCES  CUSTOMER(CUST_ID)
ALTER TABLE CUSTOMER_EXPENSE ADD CONSTRAINT FK_EXPENSE_CATEGORY FOREIGN KEY (CE_EC_ID) REFERENCES  EXPENSE_CATEGORY(EC_ID)
