CREATE TABLE `Produto` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`nome` varchar NOT NULL,
	`preco` varchar NOT NULL,
	`descricao` varchar NOT NULL,
	`imagens` varchar(255) NOT NULL,
	`qt_produto` INT NOT NULL,
	`produto_ativo` varchar(200) NOT NULL,
	`fk_id` varchar NOT NULL,
	`fk_usuario` INT NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Usuario` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`nome` varchar(50) NOT NULL,
	`email` varchar(50) NOT NULL,
	`senha` INT(50) NOT NULL,
	PRIMARY KEY (`id`)
);

CREATE TABLE `Categoria` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`nome_categoria` BOOLEAN NOT NULL DEFAULT 'not null',
	`imagem_categoria` varchar(255) NOT NULL,
	`descricao_categoria` varchar(255) NOT NULL,
	PRIMARY KEY (`id`)
);

ALTER TABLE `Produto` ADD CONSTRAINT `Produto_fk0` FOREIGN KEY (`fk_id`) REFERENCES `Categoria`(`id`);

ALTER TABLE `Produto` ADD CONSTRAINT `Produto_fk1` FOREIGN KEY (`fk_usuario`) REFERENCES `Usuario`(`id`);

