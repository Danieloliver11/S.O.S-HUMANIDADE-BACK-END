package com.example.ACSocioambiental.Model;



import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;


@Entity
@Table(name= "tb_produto")
public class Produto {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private long id;
	
	@NotNull
	@Size(min =3, max =30)
	public String nome;
	
	@NotNull
	private double preco;
	
	@NotNull
	@Size(min = 5, max= 100)
	private String descricao;
	
	@NotNull
	@Size(min = 5, max= 300)
	private String imagens;
	
	@NotNull
	private int qt_produto;
	
	@NotNull
	private boolean produto_ativo ;
	
	
	@ManyToOne
	@JsonIgnoreProperties("produto") // se der erro foi aqui
	private Categoria categoria;

	
	
	
	
	
	
	public Categoria getCategoria() {
		return categoria;
	}

	public void setCategoria(Categoria categoria) {
		this.categoria = categoria;
	}

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

	public String getImagens() {
		return imagens;
	}

	public void setImagens(String imagens) {
		this.imagens = imagens;
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
	
	
}
