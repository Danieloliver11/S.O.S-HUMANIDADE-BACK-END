package com.example.ACSocioambiental.Repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;


import com.example.ACSocioambiental.Model.Categoria;

public interface CategoriaRepository extends JpaRepository<Categoria, Long> {
	
	public interface PostagemRepository extends JpaRepository <Categoria, Long>{
		public List<Categoria> findAllByTituloContainingIgnoreCase (String titulo);

	}

}
