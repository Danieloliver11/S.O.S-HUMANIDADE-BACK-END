package com.example.ACSocioambiental.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.ACSocioambiental.Model.Produto;

@Repository
public interface ProdutoRepository extends JpaRepository<Produto, Long>{
	public List<Produto> findAllByNomeContainingIgnoreCase(String nome);
	
	public List<Produto> findAllByPrecoLessThanEqual(double preco);
	
	public List<Produto> findAllByPrecoGreaterThanEqual(double preco);
	
	@Query(value = "SELECT * FROM tb_produto WHERE ativo = :ativo", nativeQuery = true)
	public List<Produto> findAllByAtivo(@Param("ativo") boolean ativo);
	
}

//******************************