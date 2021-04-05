package com.example.ACSocioambiental.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.ACSocioambiental.Model.Produto;
import com.example.ACSocioambiental.repository.ProdutoRepository;

@RestController
@RequestMapping("/produtos")
@CrossOrigin(origins = "*")
public class ProdutoController {
	
	@Autowired
	private ProdutoRepository repository;
	
	@GetMapping
	public ResponseEntity<List<Produto>> findAllProduto(){
		
		return ResponseEntity.ok(repository.findAll());
	}
	
	@GetMapping("/{id}")
	public ResponseEntity<Produto> findByIdProduto(@PathVariable long id){
		
		return repository.findById(id)
				.map(resp -> ResponseEntity.ok(resp))
				.orElse(ResponseEntity.notFound().build());
	}
	
	@GetMapping("/nome/{nome}")
	public ResponseEntity<List<Produto>> findByNomeProduto(@PathVariable String nome){
		
		return ResponseEntity.ok(repository.findAllByNomeContainingIgnoreCase(nome));
	}
	
	/* TRAS TODOS OS VALORES <= (menores ou igual) CADASTRADOS DENTRO DE SUA TABELA */
	@GetMapping("/precoMenor/{preco}")
	public ResponseEntity<List<Produto>> findByPrecoMenorProduto(@PathVariable int preco){
		
		return ResponseEntity.ok(repository.findAllByPrecoLessThanEqual(preco));
	}
	
	/* TRAS TODOS OS VALORES >= (maiores ou igual) CADASTRADOS DENTRO DE SUA TABELA */
	@GetMapping("/precoMaior/{preco}")
	public ResponseEntity<List<Produto>> findByPrecoMaiorProduto(@PathVariable int preco){
		
		return ResponseEntity.ok(repository.findAllByPrecoGreaterThanEqual(preco));
	}
	
	@GetMapping("/ativo/{ativo}")
	public ResponseEntity<List<Produto>> findAllByAtivo(@PathVariable boolean ativo){
		
		return ResponseEntity.ok(repository.findAllByAtivo(ativo));
	}
	
	@PostMapping
	public ResponseEntity<Produto> postProduto(@RequestBody Produto produto){
		
		return ResponseEntity.status(HttpStatus.CREATED).body(repository.save(produto));
	}
	
	@PutMapping
	public ResponseEntity<Produto> putProduto(@RequestBody Produto produto){
		
		return ResponseEntity.ok(repository.save(produto));
	}
	
	@DeleteMapping("/{id}")
	public void deleteProduto(@PathVariable long id) {
		
		repository.deleteById(id);
	}

}
