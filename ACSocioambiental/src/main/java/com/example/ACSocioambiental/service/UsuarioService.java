package com.example.ACSocioambiental.service;

import java.nio.charset.Charset;
import java.util.Optional;
/*INSERIR MANUALMENTE*/
import org.apache.commons.codec.binary.Base64;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

import com.example.ACSocioambiental.Model.UserLogin;
import com.example.ACSocioambiental.Model.Usuario;
import com.example.ACSocioambiental.repository.UsuarioRepository;

@Service
public class UsuarioService {
	
	@Autowired
	private UsuarioRepository repository;
	
	/* METODO REPOSAVEL POR CADASTRAR UM USUARIO E ENCRIPTAR SUA SENHA ANTES DE SALVAR NA BASE DE DADOS */
	public Optional<Usuario> CadastrarUsuario(Usuario usuario) {	
		
		/* CONDICAO PARA INPEDIR A CRIACAO DE UM USUARIO DUPLICADO DENTRO DA APLICACAO */
		if(repository.findByUsuario(usuario.getUsuario()).isPresent()) {
			return null;
			
		}
		
		/* CLASSE QUE E RESPOSAVEL POR ENCRIPTAR A SENHA */
		BCryptPasswordEncoder encoder = new BCryptPasswordEncoder();
		
		/* RECEBE NOSSA SENHA, ENCRIPTA SA SENHA E SALVA ELA NOVAMENTE DETRO DE NOSSO ATRIBUTO SENHA */
		String senhaEncoder = encoder.encode(usuario.getSenha());
		usuario.setSenha(senhaEncoder);
		
		/* RETORNAMOS ESSE DADO ATUALIZADO DENTRO DO NOSSO OBJETO USUARIO */
		return Optional.of(repository.save(usuario));
	}
	
	/* METODO RESPOSAVEL POR VALIDAR NOSSSO LOGIN AO ACESSAR A APLICACAO */
	/* RECEBEMOS OS DADOS VINDOS DO BODY(O QUE O USUARIO ACABOU DE DIGITAR PARA LOGAR) E ARAMZEMOS ESSES DADOS DENTRO DE NOSSA CLASSE 'UserLogin <- Classe auxiliar'*/
	public Optional<UserLogin> Logar(Optional<UserLogin> user) {

		BCryptPasswordEncoder encoder = new BCryptPasswordEncoder();
		Optional<Usuario> usuario = repository.findByUsuario(user.get().getUsuario());
		
		/* CASO TENHA ALGUM VALOR DIGITADO, IREMOS COMPARAR OS DADOS QUE ESTAO CADASTRADOS NA BASE DE DADOS COM O QUE O USUARIO ACABOU DE DIGITAR */
		if (usuario.isPresent()) {
			/* COMPARA O QUE FOI DIGITADO NO BODY COM O QUE ESTA NO BANCO DE DADOS REFERENTE AQUELE DETERMINADO USUARIO */
			if (encoder.matches(user.get().getSenha(), usuario.get().getSenha())) {
				
				/* CRIA UMA STRING COM O 'NOME_USUARIO:SENHA' */
				String auth = user.get().getUsuario() + ":" + user.get().getSenha();
				
				/* CRIA UM ARRAY DE BYTE, QUE RECEBE A STRING GERADA ACIMA E FORMATA NO PADRAO 'US-ASCII' */
				byte[] encodedAuth = Base64.encodeBase64(auth.getBytes(Charset.forName("US-ASCII")));
				
				/* GERA O TOKEN PARA ACESSO DE USUARIO POR MEIO DO ARRAY DE BY GERADO */
				String authHeader = "Basic " + new String(encodedAuth);
				
				/* INSERE O TOKEN GERADO DENTRO DE NOSSO ATRIBUTO TOKEN */
				user.get().setToken(authHeader);				
				user.get().setNome(usuario.get().getNome());
				user.get().setSenha(usuario.get().getSenha());
				user.get().setFoto(usuario.get().getFoto());;
                user.get().setTipo(usuario.get().getTipo());
                user.get().setId(usuario.get().getId());


				
			
				
				return user;

			}
		}
		
		return null;
	}

}