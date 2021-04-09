package com.example.ACSocioambiental.controller;

import java.util.Optional;

import com.example.ACSocioambiental.Model.UserLogin;
import com.example.ACSocioambiental.Model.Usuario;
import com.example.ACSocioambiental.service.UsuarioService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/usuarios")
/* allowedHeaders <- dentro do header, nos tambem aceitamos quais quer informacoes */
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class UsuarioController {
	
	@Autowired
	private UsuarioService usuarioService;
	
	/* PARA LOGARMOS NO SISITEMA TRABALHAMOS COM A CLASSE 'UserLogin' */
	@PostMapping("/logar")
	public ResponseEntity<UserLogin> Autentication(@RequestBody Optional<UserLogin> user) {
		return usuarioService.Logar(user).map(resp -> ResponseEntity.ok(resp))
				/* CASO SEU USUARIO SEJA INVALIDO VOCE RECEBERA UM ERRO DE NAO AUTORIZADO */
				.orElse(ResponseEntity.status(HttpStatus.UNAUTHORIZED).build());
	}
	
	/* CHAMA O METODO DE CADASTRAR USUARIOS QUE E RESPONSAVEL POR VERIFICAR SE O USUARIO INSERIDO JA SE ENCONTRA NA BASE DE DADOS, CODIFICAR A SENHA INSERIDA E SALVAR OS DADOS CADASTRADO NA BASE DE DADOS */
	@PostMapping("/cadastrar")
	public ResponseEntity<Usuario> Post(@RequestBody Usuario usuario) {
		Optional<Usuario> user = usuarioService.CadastrarUsuario(usuario);
		
		try {
			return ResponseEntity.ok(user.get());
			
		}catch(Exception e) {
			return ResponseEntity.badRequest().build();
			
		}
		
	}

}