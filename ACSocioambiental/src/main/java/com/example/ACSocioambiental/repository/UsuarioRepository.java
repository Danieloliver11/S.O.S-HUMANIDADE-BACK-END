package com.example.ACSocioambiental.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.ACSocioambiental.Model.Usuario;

@Repository
public interface UsuarioRepository extends JpaRepository<Usuario, Long>{
	
	/* PESQUISE PELO NOME DE USUARIO */
	public Optional<Usuario> findByUsuario(String usuario);

}
