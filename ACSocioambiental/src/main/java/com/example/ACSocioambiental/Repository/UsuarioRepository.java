package com.example.ACSocioambiental.Repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.ACSocioambiental.Model.Usuario;

public interface UsuarioRepository extends JpaRepository<Usuario, Long>{
	
	public Optional<Usuario> findByUsuario (String usuario);

}
