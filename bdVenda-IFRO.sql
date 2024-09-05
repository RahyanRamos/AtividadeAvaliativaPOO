create database aula_23_07;
use aula_23_07;

create table Funcionario(
	id_funcionario int unsigned primary key auto_increment,
    nome_func varchar(100) not null,
    cpf_func varchar(14) not null
);

create table Caixa(
	id_caixa int unsigned primary key auto_increment,
    saldoInicial_cai double,
    totalEntradas_cai double,
    totalSaidas_cai double,
    status_cai varchar(50),
    fk_funcionario int unsigned not null,
    foreign key(fk_funcionario) references Funcionario(id_funcionario)
);

create table Despesa(
	id_despesa int unsigned primary key auto_increment,
    valor_desp double not null,
    dataVencimento_desp date,
    dataPagamento_desp date,
    status_desp varchar(50),
    fk_caixa int unsigned,
    foreign key(fk_caixa) references Caixa(id_caixa)
);

create table Dispositivo(
	id_dispositivo int unsigned primary key auto_increment,
    aliquota_disp double,
    descricao_disp text,
    status_disp varchar(50)
);

create table Cliente(
	id_cliente int unsigned primary key auto_increment,
    nome_cli varchar(255) not null,
    cpf_cli varchar(14) not null,
    email_cli varchar(255),
    telefone_cli varchar(30),
    nascimento_cli date
);

create table Servico(
	id_servico int unsigned primary key auto_increment,
    valor_serv double,
    descricao_serv text,
    tempo_serv time
);

create table Venda(
	id_venda int unsigned primary key auto_increment,
    data_vend date,
    hora_vend time,
    valorTotal_vend double,
    desconto_vend double,
    valorFinal_vend double,
    tipo_vend varchar(50),
    fk_cliente int unsigned,
    foreign key(fk_cliente) references Cliente(id_cliente)
);

create table Venda_Servico(
	id_vs int unsigned primary key auto_increment,
    quantidade_vs int,
    valorTotal_vs double,
    fk_servico int unsigned not null,
    foreign key(fk_servico) references Servico(id_servico),
    fk_venda int unsigned,
    foreign key(fk_venda) references Venda(id_venda) on delete cascade
);

create table Recebimento(
	id_recebimento int unsigned primary key auto_increment,
    valor_rec double,
    vencimento_rec date,
    pagamento_rec date,
    status_rec varchar(50),
    fk_caixa int unsigned not null,
    foreign key(fk_caixa) references Caixa(id_caixa),
    fk_venda int unsigned,
    foreign key(fk_venda) references Venda(id_venda)
);

create table Encargo(
	id_encargo int unsigned primary key auto_increment,
    valor_enc double,
    descricao_enc text,
    fk_dispositivo int unsigned not null,
    foreign key(fk_dispositivo) references Dispositivo(id_dispositivo),
    fk_recebimento int unsigned not null,
    foreign key(fk_recebimento) references Recebimento(id_recebimento)
);

SHOW CREATE TABLE Encargo;
 
 ALTER TABLE Encargo DROP FOREIGN KEY encargo_ibfk_2;
 
 ALTER TABLE Encargo
ADD CONSTRAINT fk_recebimento
FOREIGN KEY (fk_recebimento) REFERENCES Recebimento(id_recebimento)
ON DELETE CASCADE;

insert into Servico values
    (null, 2.50, "Calibragem de pneu", "00:05:00"),
    (null, 12, "Troca dos faróis e lanternas", "00:17:10"),
    (null, 35, "Troca dos óleos", "01:11:00"),
    (null, 122, "Instalação de som e multimidia", "02:00:00"),
    (null, 78, "Instalação do aerofólio", "00:20:54"),
    (null, 22, "Lavagem do veículo", "00:30:00");


update Servico set valor_serv = 30 where id_servico = 1;

insert into Cliente values(null, "Arnaldo Silva", "123.456.789=10", "arnaldo@gmail.com", "(69) 99215-1872", "1977-04-05");

insert into Venda values(null, "2024-07-23", "16:34:56", 27, 2, 25, "À vista", 1);

insert into Venda_Servico values(null, 1, 25, 1, 2);

insert into Venda values 
	(null, "2024-07-30", "21:16:50", 78, 15, 63, "Boleto", 1),
    (null, "2024-07-29", "22:44:05", 321, 21, 300, "Cartão Débito", 2);
    
insert into Recebimento values 
	(null, 567, "2024-10-06", "2024-10-22", "Atrasado", 2, 4),
    (null, 42, "2024-10-06", "2024-09-22", "No Prazo", 1, 2),
    (null, 857, "2024-09-11", "2024-09-30", "Pago", 1, 3);
    
insert into Dispositivo values
	(null, 15, "InfinitePay", "Ativo");
    
insert into Encargo values
	(null, 456, "Encargo Stone", 1, 6),
    (null, 21, "Encargo InfinitePay", 2, 5);
    
insert into funcionario values
	(null, "João Fragoso Freitas", "536.796.546-23"),
    (null, "Alex Durex", "221.487.643-35");
    
insert into caixa values
	(null, 13454, 5564, 7852, "Aberto", 1),
	(null, 4477, 4757, 575, "Aberto", 2);
    
insert into despesa values
	(null, 21878, "2024-09-06", "2024-08-06", "Pago", 2),
    (null, 43558, "2024-12-01", null, "Em Aberto", 1);
    
insert into dispositivos values
	(null, 2, "PagBank", "Ativo"),
    (null, 7.5, "Stone", "Ativo");
    
insert into cliente values
	(null, "Maria Joaquina", "645.487.973-56", "mariajoca@gmail.com", "(69) 99354-1863", "2000-03-18");
    
insert into venda values
	(null, "2024-08-06", "20:08:00", 43, 0, 43, "Fiado", null);
    
insert into venda_servico values
	(null, 4, 1768, 1, 1),
    (null, 2, 422, 2, 1),
    (null, 5, 75, 1, 2);

insert into servico values
	(null, 4528, "Refazer motor", "08:12:00"),
    (null, 4586, "Stage 3", "05:00:00");

insert into recebimento values
	(null, 2567, "2024-08-06", "2024-08-06", "Pago", 1, 2),
	(null, 5457, "2024-08-06", "2024-08-06", "Pago", 2, 1);
    
