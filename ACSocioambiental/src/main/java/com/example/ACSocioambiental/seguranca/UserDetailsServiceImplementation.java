package com.example.ACSocioambiental.seguranca;

import java.util.Optional;

import com.example.ACSocioambiental.Model.Usuario;
import com.example.ACSocioambiental.repository.UsuarioRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class UserDetailsServiceImplementation implements UserDetailsService {
	
	@Autowired
	private UsuarioRepository userRepository;
	
	@Override
	public UserDetails loadUserByUsername(String userName) throws UsernameNotFoundException {
		
		/* PARA VALIDAR O LOGIN, VERIFICAMOS SE O USUARIO CADASTRADOS SE ENCONTRA EM NOSSA BASE DE DADOS */
		Optional<Usuario> user = userRepository.findByUsuario(userName);
		
		/* CASE DE ERRO, INFORMAMOS O USUARIO INSERIDO E INFORMAMOS QUE O MESMO NAO EXISTE EM NOSSA BASE DE DADOS */
		user.orElseThrow(() -> new UsernameNotFoundException(userName + " not found."));
		
		/* CASO O USUARIO ESTAJA CADASTRADO EM NOSSA BASE DE DADOS, RETORNAMOS O LOGIN BEM SUCEDIDO DO USUARIO */
		return user.map(UserDetailsImplementation::new).get();
	}

}
