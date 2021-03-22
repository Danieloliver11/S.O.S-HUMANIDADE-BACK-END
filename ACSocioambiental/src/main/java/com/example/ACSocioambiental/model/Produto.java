package com.example.ACSocioambiental.model;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@Entity
@Table (name = "produto")
public class Produto {
	
	@Id
	@GeneratedValue (strategy = GenerationType.IDENTITY)
	private long id_produto;
	
	@NotNull
	@Size (min = 5, max = 100)
	private String nome_produto;
	
	@NotNull
	private double preco;
	
	@NotNull
	@Size (min = 5, max = 200)
	private String descricao;
	
	@NotNull
	@Size (min = 5, max = 250)
	private String imagem_produto;
	
	@NotNull
	private int qt_produto;
	
	@NotNull
	private boolean produto_ativo;
	
	@ManyToOne
	@JsonIgnoreProperties("produto")
    private Categoria categoria;
	
	@ManyToOne
	@JsonIgnoreProperties("produto")
    private Usuario usuario;

	public long getId_produto() {
		return id_produto;
	}

	public void setId_produto(long id_produto) {
		this.id_produto = id_produto;
	}

	public String getNome_produto() {
		return nome_produto;
	}

	public void setNome_produto(String nome_produto) {
		this.nome_produto = nome_produto;
	}

	public double getPreco() {
		return preco;
	}

	public void setPreco(double preco) {
		this.preco = preco;
	}

	public String getDescricao() {
		return descricao;
	}

	public void setDescricao(String descricao) {
		this.descricao = descricao;
	}

	public String getImagem_produto() {
		return imagem_produto;
	}

	public void setImagem_produto(String imagem_produto) {
		this.imagem_produto = imagem_produto;
	}

	public int getQt_produto() {
		return qt_produto;
	}

	public void setQt_produto(int qt_produto) {
		this.qt_produto = qt_produto;
	}

	public boolean isProduto_ativo() {
		return produto_ativo;
	}

	public void setProduto_ativo(boolean produto_ativo) {
		this.produto_ativo = produto_ativo;
	}

	public Categoria getCategoria() {
		return categoria;
	}

	public void setCategoria(Categoria categoria) {
		this.categoria = categoria;
	}

	public Usuario getUsuario() {
		return usuario;
	}

	public void setUsuario(Usuario usuario) {
		this.usuario = usuario;
	}
	

}