DROP database gestcom
create database gestcom
use gestcom
create table FAMILLES(idFamille int primary key,Famille varchar(100))
create table ARTICLES(REF varchar(20)primary key,IdFamille int foreign key references FAMILLES(IdFamille)on delete cascade on update cascade,Description varchar(200),PU_ACHAT int,PU_VENTE int,QTE_STOCK int,TxTVA decimal(9,2))
create table CLIENTS(IdClient int primary key ,RaisonSocial varchar(100),Adresse varchar(100),Ville varchar(30),TEL varchar(10)) 
create table BL(NumBL varchar(10) primary key,IdClient int foreign key references CLIENTS(IdClient)on delete cascade on update cascade,DateBL datetime ,OBSERVATION varchar(500))
create table DETAIL_BL(REF varchar(20)foreign key references ARTICLES(REF) on delete cascade on update cascade,NumBL varchar(10)foreign key references BL(NumBL)on delete cascade on update cascade,QTE int,Prix_VenteHT int,TxRemise decimal(9,2),PT_HT as((Prix_VenteHT-(Prix_VenteHT*TxRemise))* QTE),PT_TTC int,primary key(NumBL,REF))
create table DEVIS(NumDevis varchar(10) primary key ,IdClient int foreign key references CLIENTS(IdClient)on delete cascade on update cascade,DateDevis date,OBSERVATION varchar(500)) 
create table DETAIL_DEVIS(NumDevis varchar(10) foreign key references DEVIS(NumDevis)on delete cascade on update cascade,REF varchar(20) foreign key references ARTICLES(REF)on delete cascade on update cascade,QTE int,PRIX_VENTEHT int,TxRemise decimal(9,2),PT_HT as((Prix_VenteHT-(Prix_VenteHT*TxRemise))* Qte),PT_TTC int,primary key(NumDevis,REF))
--trigger for Update Numero DEVIS to xxxxx/Year
go
create trigger trgr on DEVIS for insert as begin
  declare @newnum varchar(10), @year varchar(10)
  set @year = convert(varchar(10),(year(getdate())))
  set @newnum =(select NumDevis from inserted)
  delete DEVIS where NumDevis = @newnum 
  insert into DEVIS values( right('0000'+@newnum + '/' +@year ,10) , (select IdClient from inserted),(select DateDevis from inserted),(select OBSERVATION from inserted))
  end 
  --trigger for Update Numero BL to xxxxx/Year
go
create trigger trgr2 on BL for insert as begin
  declare @newnum2 varchar(10), @year2 varchar(10)
  set @year2 = convert(varchar(10),(year(getdate())))
  set @newnum2 =(select NumBL from inserted)
  delete BL where NumBL = @newnum2 
  insert into BL values( right('0000'+@newnum2 + '/' +@year2 ,10) , (select IdClient from inserted),(select DateBL from inserted),(select OBSERVATION from inserted))
  end
  -- Ce trigger va mettre a jour les stocks des articles qui sont suivi en DETAIL_DEVIS
go
create trigger MettreajourQte on DETAIL_DEVIS after delete,insert ,update as begin
declare @s int,@R int,@Q int
select @R =REF, @Q=QTE from deleted
update ARTICLES
set QTE_STOCK=QTE_STOCK+@Q where @R=REF
set @Q=0
select @R =REF,@Q=QTE from inserted
select @s=QTE_STOCK from ARTICLES where @R=REF
if @s< @Q 
begin
print 'desole QTE_STOCK n est pas disponible commadez une QTE<= '+convert(varchar,@s)
rollback transaction
end
else begin
update ARTICLES
set QTE_STOCK=QTE_STOCK-@Q where @R=REF
end
end
