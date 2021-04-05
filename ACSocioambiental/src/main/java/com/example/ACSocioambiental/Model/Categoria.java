package com.example.ACSocioambiental.Model;

import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import org.hibernate.validator.constraints.URL;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@Entity
@Table(name = "tb_categoria")
public class Categoria {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private long id;
	
	@NotNull
<<<<<<< HEAD
	@Size(max =50)
	private String nomeCategoria;
	
	@URL
	@NotNull
	private String imagemCategoria;
	
	@Size(max= 10000)
	private String descricaoCategoria;
	
	@OneToMany(mappedBy = "categoria", cascade = CascadeType.ALL)
	@JsonIgnoreProperties("categoria") 
	private List<Produto> produto;

	public long getId() {
		return id;
=======
	@Size(min = 5, max =50)
	private String nome;
	
	@URL
	private String imagem;
	
	@NotNull
	@Size(min=5 , max= 200)
	private String descricao;
	
	@OneToMany(mappedBy = "categoria", cascade = CascadeType.ALL)
	@JsonIgnoreProperties("categoria")
	private List<Produto> produto;
	
	public List<Produto> getProduto() {
		return produto;
>>>>>>> a7c67b4cd55f2304a80fa5d946eee09519f07690
	}

	public void setId(long id) {
		this.id = id;
	}

<<<<<<< HEAD
	public String getNomeCategoria() {
		return nomeCategoria;
	}

	public void setNomeCategoria(String nomeCategoria) {
		this.nomeCategoria = nomeCategoria;
	}

	public String getImagemCategoria() {
		return imagemCategoria;
	}

	public void setImagemCategoria(String imagemCategoria) {
		this.imagemCategoria = imagemCategoria;
	}

	public String getDescricaoCategoria() {
		return descricaoCategoria;
	}

	public void setDescricaoCategoria(String descricaoCategoria) {
		this.descricaoCategoria = descricaoCategoria;
	}

	public List<Produto> getProduto() {
		return produto;
	}

	public void setProduto(List<Produto> produto) {
		this.produto = produto;
=======
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getNome() {
		return nome;
	}

	public void setNome(String nome) {
		this.nome = nome;
	}

	public String getDescricao() {
		return descricao;
	}

	public void setDescricao(String descricao) {
		this.descricao = descricao;
	}

	public String getImagem() {
		return imagem;
	}

	public void setImagem(String imagem) {
		this.imagem = imagem;
>>>>>>> a7c67b4cd55f2304a80fa5d946eee09519f07690
	}

	
<<<<<<< HEAD

	
	
=======
>>>>>>> a7c67b4cd55f2304a80fa5d946eee09519f07690
}
