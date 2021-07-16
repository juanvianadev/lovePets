USE lovePets_manha;
GO

INSERT INTO clinica(razaoSocial, cnpj, endereco)
VALUES			   ('lovePets', '99999999999999', 'Al. Bar�o de Limeira, 538');
GO

INSERT INTO tipoPet(nomeTipoPet)
VALUES			   ('cachorro'),
				   ('gato');
GO

INSERT INTO raca(idTipoPet, nomeRaca)
VALUES			(1, 'poodle'),
				(1, 'labrador'),
				(1, 'SRD'),
				(2, 'siam�s');
GO

INSERT INTO dono(nomeDono)
VALUES			('Paulo'),
				('Odirlei');
GO

INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES				   ('administrador'),
					   ('veterin�rio'),
					   ('pet');
GO

INSERT INTO usuario(idTipoUsuario, email, senha)
VALUES			   (1, 'adm@adm.com', 'adm123'),
			       (2, 'saulo@email.com', 'saulo123'),
				   (2, 'caique@email.com', 'caique123'),
				   (3, 'junior@email.com', 'junior123'),
				   (3, 'loli@email.com', 'loli123'),
				   (3, 'sammy@email.com', 'sammy123');
GO

INSERT INTO pet(nomePet, dataNascimento, idRaca, idDono, ra, idUsuario)
VALUES		   ('junior', '10/10/2018', 1, 1, '9999999', 4),
			   ('loli', '18/05/2017', 4, 1, '8888888', 5),
			   ('sammy', '16/06/2016', 1, 2, '7777777', 6);
GO

INSERT INTO veterinario(idClinica, CRMV, nomeVeterinario, idUsuario)
VALUES				   (1, '432551', 'Saulo', 2),
					   (1, '653655', 'Caique', 3);
GO

INSERT INTO situacao(nomeSituacao)
VALUES				('realizada'),
					('agendada'),
					('cancelada');
GO

INSERT INTO atendimento(idVeterinario, idPet, descricao, dataAtendimento, idSituacao)
VALUES				   (1, 1, 'restam 10 dias de vida', '15/07/2021 10:00', 1),
					   (2, 2, 'o paciente est� ok', '16/07/2021 11:00', 2),
					   (2, 1, 'o paciente est� ok', '17/07/2021 15:00', 3);
GO