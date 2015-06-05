-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 05-Jun-2015 às 03:03
-- Versão do servidor: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

CREATE DATABASE banco_escolar;
--
-- Database: `banco_escolar`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_aluno`
--

CREATE TABLE IF NOT EXISTS `tbl_aluno` (
  `alu_id` int(11) NOT NULL AUTO_INCREMENT,
  `alu_nome` varchar(100) DEFAULT NULL,
  `alu_prontuario` char(7) DEFAULT NULL,
  `alu_endereco` varchar(255) DEFAULT NULL,
  `alu_cpf` char(11) DEFAULT NULL,
  `alu_telefone` varchar(15) DEFAULT NULL,
  `alu_email` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`alu_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_aluno_has_tbl_turma`
--

CREATE TABLE IF NOT EXISTS `tbl_aluno_has_tbl_turma` (
  `tbl_aluno_alu_id` int(11) NOT NULL,
  `tbl_turma_tur_id` int(11) NOT NULL,
  PRIMARY KEY (`tbl_aluno_alu_id`,`tbl_turma_tur_id`),
  KEY `fk_tbl_aluno_has_tbl_turma_tbl_turma1_idx` (`tbl_turma_tur_id`),
  KEY `fk_tbl_aluno_has_tbl_turma_tbl_aluno1_idx` (`tbl_aluno_alu_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_curso`
--

CREATE TABLE IF NOT EXISTS `tbl_curso` (
  `cur_id` int(11) NOT NULL AUTO_INCREMENT,
  `cur_nome` varchar(100) DEFAULT NULL,
  `cur_duracao` int(11) DEFAULT NULL,
  `cur_periodo` char(1) DEFAULT NULL,
  PRIMARY KEY (`cur_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_curso_has_tbl_disciplina`
--

CREATE TABLE IF NOT EXISTS `tbl_curso_has_tbl_disciplina` (
  `tbl_curso_cur_id` int(11) NOT NULL,
  `tbl_disciplina_dis_id` int(11) NOT NULL,
  PRIMARY KEY (`tbl_curso_cur_id`,`tbl_disciplina_dis_id`),
  KEY `fk_tbl_curso_has_tbl_disciplina_tbl_disciplina1_idx` (`tbl_disciplina_dis_id`),
  KEY `fk_tbl_curso_has_tbl_disciplina_tbl_curso1_idx` (`tbl_curso_cur_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_disciplina`
--

CREATE TABLE IF NOT EXISTS `tbl_disciplina` (
  `dis_id` int(11) NOT NULL AUTO_INCREMENT,
  `dis_sigla` varchar(6) DEFAULT NULL,
  `dis_nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`dis_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_disciplina_has_tbl_professor`
--

CREATE TABLE IF NOT EXISTS `tbl_disciplina_has_tbl_professor` (
  `tbl_disciplina_dis_id` int(11) NOT NULL,
  `tbl_professor_pro_id` int(11) NOT NULL,
  PRIMARY KEY (`tbl_disciplina_dis_id`,`tbl_professor_pro_id`),
  KEY `fk_tbl_disciplina_has_tbl_professor_tbl_professor1_idx` (`tbl_professor_pro_id`),
  KEY `fk_tbl_disciplina_has_tbl_professor_tbl_disciplina_idx` (`tbl_disciplina_dis_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_funcionario`
--

CREATE TABLE IF NOT EXISTS `tbl_funcionario` (
  `fun_id` int(11) NOT NULL,
  `fun_nome` varchar(100) DEFAULT NULL,
  `fun_matricula` varchar(10) DEFAULT NULL,
  `tbl_login_log_login` varchar(15) NOT NULL,
  PRIMARY KEY (`fun_id`,`tbl_login_log_login`),
  KEY `fk_tbl_funcionario_tbl_login1_idx` (`tbl_login_log_login`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_login`
--

CREATE TABLE IF NOT EXISTS `tbl_login` (
  `log_login` varchar(15) NOT NULL,
  `log_nome` varchar(45) NOT NULL,
  `log_senha` varchar(15) NOT NULL,
  `log_poderes` char(6) NOT NULL,
  PRIMARY KEY (`log_login`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `tbl_login`
--

INSERT INTO `tbl_login` (`log_login`, `log_nome`, `log_senha`, `log_poderes`) VALUES
('henrique', 'Henrique Fernandes', '1234567', 'ADM');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_professor`
--

CREATE TABLE IF NOT EXISTS `tbl_professor` (
  `pro_id` int(11) NOT NULL AUTO_INCREMENT,
  `pro_nome` varchar(100) DEFAULT NULL,
  `pro_prontuario` char(7) DEFAULT NULL,
  `pro_endereco` varchar(255) DEFAULT NULL,
  `pro_cpf` char(11) DEFAULT NULL,
  `pro_telefone` varchar(15) DEFAULT NULL,
  `pro_email` varchar(30) DEFAULT NULL,
  `tbl_login_log_login` varchar(15) NOT NULL,
  PRIMARY KEY (`pro_id`,`tbl_login_log_login`),
  KEY `fk_tbl_professor_tbl_login1_idx` (`tbl_login_log_login`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_turma`
--

CREATE TABLE IF NOT EXISTS `tbl_turma` (
  `tur_id` int(11) NOT NULL AUTO_INCREMENT,
  `tur_numero` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`tur_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbl_turma_has_tbl_disciplina`
--

CREATE TABLE IF NOT EXISTS `tbl_turma_has_tbl_disciplina` (
  `tbl_turma_tur_id` int(11) NOT NULL,
  `tbl_disciplina_dis_id` int(11) NOT NULL,
  PRIMARY KEY (`tbl_turma_tur_id`,`tbl_disciplina_dis_id`),
  KEY `fk_tbl_turma_has_tbl_disciplina_tbl_disciplina1_idx` (`tbl_disciplina_dis_id`),
  KEY `fk_tbl_turma_has_tbl_disciplina_tbl_turma1_idx` (`tbl_turma_tur_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `tbl_aluno_has_tbl_turma`
--
ALTER TABLE `tbl_aluno_has_tbl_turma`
  ADD CONSTRAINT `fk_tbl_aluno_has_tbl_turma_tbl_aluno1` FOREIGN KEY (`tbl_aluno_alu_id`) REFERENCES `tbl_aluno` (`alu_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_aluno_has_tbl_turma_tbl_turma1` FOREIGN KEY (`tbl_turma_tur_id`) REFERENCES `tbl_turma` (`tur_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tbl_curso_has_tbl_disciplina`
--
ALTER TABLE `tbl_curso_has_tbl_disciplina`
  ADD CONSTRAINT `fk_tbl_curso_has_tbl_disciplina_tbl_curso1` FOREIGN KEY (`tbl_curso_cur_id`) REFERENCES `tbl_curso` (`cur_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_curso_has_tbl_disciplina_tbl_disciplina1` FOREIGN KEY (`tbl_disciplina_dis_id`) REFERENCES `tbl_disciplina` (`dis_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tbl_disciplina_has_tbl_professor`
--
ALTER TABLE `tbl_disciplina_has_tbl_professor`
  ADD CONSTRAINT `fk_tbl_disciplina_has_tbl_professor_tbl_disciplina` FOREIGN KEY (`tbl_disciplina_dis_id`) REFERENCES `tbl_disciplina` (`dis_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_disciplina_has_tbl_professor_tbl_professor1` FOREIGN KEY (`tbl_professor_pro_id`) REFERENCES `tbl_professor` (`pro_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tbl_funcionario`
--
ALTER TABLE `tbl_funcionario`
  ADD CONSTRAINT `fk_tbl_funcionario_tbl_login1` FOREIGN KEY (`tbl_login_log_login`) REFERENCES `tbl_login` (`log_login`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tbl_professor`
--
ALTER TABLE `tbl_professor`
  ADD CONSTRAINT `fk_tbl_professor_tbl_login1` FOREIGN KEY (`tbl_login_log_login`) REFERENCES `tbl_login` (`log_login`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Limitadores para a tabela `tbl_turma_has_tbl_disciplina`
--
ALTER TABLE `tbl_turma_has_tbl_disciplina`
  ADD CONSTRAINT `fk_tbl_turma_has_tbl_disciplina_tbl_turma1` FOREIGN KEY (`tbl_turma_tur_id`) REFERENCES `tbl_turma` (`tur_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_tbl_turma_has_tbl_disciplina_tbl_disciplina1` FOREIGN KEY (`tbl_disciplina_dis_id`) REFERENCES `tbl_disciplina` (`dis_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
