[33mcommit 7094167deb51dfa0ca4fcd1b5729116dfc732f55[m[33m ([m[1;36mHEAD -> [m[1;32mmain[m[33m, [m[1;31morigin/daniel[m[33m, [m[1;31morigin/criacao-camada-security[m[33m, [m[1;32mdaniel[m[33m, [m[1;32mcriacao-camada-security[m[33m)[m
Author: Clamant96 <kevin.lazzarotto@hotmail.com>
Date:   Fri Apr 9 12:58:38 2021 -0300

    Criacao de camada security com as implementacoes para cadastros de usuarios e validacao de login com a criacao de token para acesso aos conteudos da plataforma

[1mdiff --git a/ACSocioambiental/pom.xml b/ACSocioambiental/pom.xml[m
[1mindex 7853328..413860e 100644[m
[1m--- a/ACSocioambiental/pom.xml[m
[1m+++ b/ACSocioambiental/pom.xml[m
[36m@@ -17,6 +17,15 @@[m
 		<java.version>1.8</java.version>[m
 	</properties>[m
 	<dependencies>[m
[32m+[m		[32m<dependency>[m
[32m+[m			[32m<groupId>org.springframework.boot</groupId>[m
[32m+[m			[32m<artifactId>spring-boot-starter-security</artifactId>[m
[32m+[m		[32m</dependency>[m
[32m+[m		[32m<dependency>[m
[32m+[m			[32m<groupId>commons-codec</groupId>[m
[32m+[m			[32m<artifactId>commons-codec</artifactId>[m
[32m+[m			[32m<version>1.10</version>[m
[32m+[m		[32m</dependency>[m
 		<dependency>[m
 			<groupId>org.springframework.boot</groupId>[m
 			<artifactId>spring-boot-starter-data-jpa</artifactId>[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/UserLogin.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/UserLogin.java[m
[1mnew file mode 100644[m
[1mindex 0000000..28663e4[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/UserLogin.java[m
[36m@@ -0,0 +1,45 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.Model;[m
[32m+[m
[32m+[m[32mpublic class UserLogin {[m
[32m+[m[41m	[m
[32m+[m[32mprivate String nome;[m
[32m+[m[41m	[m
[32m+[m	[32mprivate String usuario;[m
[32m+[m[41m	[m
[32m+[m	[32mprivate String senha;[m
[32m+[m[41m	[m
[32m+[m	[32mprivate String token;[m
[32m+[m
[32m+[m	[32mpublic String getNome() {[m
[32m+[m		[32mreturn nome;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setNome(String nome) {[m
[32m+[m		[32mthis.nome = nome;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getUsuario() {[m
[32m+[m		[32mreturn usuario;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setUsuario(String usuario) {[m
[32m+[m		[32mthis.usuario = usuario;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getSenha() {[m
[32m+[m		[32mreturn senha;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setSenha(String senha) {[m
[32m+[m		[32mthis.senha = senha;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getToken() {[m
[32m+[m		[32mreturn token;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setToken(String token) {[m
[32m+[m		[32mthis.token = token;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java[m
[1mindex 0201537..eb3cd6a 100644[m
[1m--- a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java[m
[36m@@ -5,6 +5,7 @@[m [mimport javax.persistence.GeneratedValue;[m
 import javax.persistence.GenerationType;[m
 import javax.persistence.Id;[m
 import javax.persistence.Table;[m
[32m+[m[32mimport javax.validation.constraints.Email;[m
 import javax.validation.constraints.NotNull;[m
 import javax.validation.constraints.Size;[m
 [m
[36m@@ -17,17 +18,21 @@[m [mpublic class Usuario {[m
 	private long id;[m
 	[m
 	@NotNull[m
[31m-	@Size(min=1, max=200)[m
[32m+[m	[32m@Size(min=5, max=50)[m
 	private String nome;[m
 	[m
 	@NotNull[m
[31m-	@Size(min=1, max=200)[m
[32m+[m	[32m@Email[m
 	private String email;[m
 	[m
 	@NotNull[m
[31m-	@Size(min=1, max=200)[m
[32m+[m	[32m@Size(max=100)[m
 	private String senha ;[m
 	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32m@Size(min = 5, max = 100)[m
[32m+[m	[32mprivate String usuario;[m
[32m+[m[41m	[m
 	public long getId() {[m
 		return id;[m
 	}[m
[36m@@ -59,6 +64,13 @@[m [mpublic class Usuario {[m
 	public void setSenha(String senha) {[m
 		this.senha = senha;[m
 	}[m
[31m-	[m
[32m+[m
[32m+[m	[32mpublic String getUsuario() {[m
[32m+[m		[32mreturn usuario;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setUsuario(String usuario) {[m
[32m+[m		[32mthis.usuario = usuario;[m
[32m+[m	[32m}[m
 	[m
 }[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/UsuarioController.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/UsuarioController.java[m
[1mnew file mode 100644[m
[1mindex 0000000..b92c08e[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/UsuarioController.java[m
[36m@@ -0,0 +1,49 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.controller;[m
[32m+[m
[32m+[m[32mimport java.util.Optional;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.UserLogin;[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Usuario;[m
[32m+[m[32mimport com.example.ACSocioambiental.service.UsuarioService;[m
[32m+[m[32mimport org.springframework.beans.factory.annotation.Autowired;[m
[32m+[m[32mimport org.springframework.http.HttpStatus;[m
[32m+[m[32mimport org.springframework.http.ResponseEntity;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.CrossOrigin;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.PostMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RequestBody;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RequestMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RestController;[m
[32m+[m
[32m+[m[32m@RestController[m
[32m+[m[32m@RequestMapping("/usuarios")[m
[32m+[m[32m/* allowedHeaders <- dentro do header, nos tambem aceitamos quais quer informacoes */[m
[32m+[m[32m@CrossOrigin(origins = "*", allowedHeaders = "*")[m
[32m+[m[32mpublic class UsuarioController {[m
[32m+[m[41m	[m
[32m+[m	[32m@Autowired[m
[32m+[m	[32mprivate UsuarioService usuarioService;[m
[32m+[m[41m	[m
[32m+[m	[32m/* PARA LOGARMOS NO SISITEMA TRABALHAMOS COM A CLASSE 'UserLogin' */[m
[32m+[m	[32m@PostMapping("/logar")[m
[32m+[m	[32mpublic ResponseEntity<UserLogin> Autentication(@RequestBody Optional<UserLogin> user) {[m
[32m+[m		[32mreturn usuarioService.Logar(user).map(resp -> ResponseEntity.ok(resp))[m
[32m+[m				[32m/* CASO SEU USUARIO SEJA INVALIDO VOCE RECEBERA UM ERRO DE NAO AUTORIZADO */[m
[32m+[m				[32m.orElse(ResponseEntity.status(HttpStatus.UNAUTHORIZED).build());[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m/* CHAMA O METODO DE CADASTRAR USUARIOS QUE E RESPONSAVEL POR VERIFICAR SE O USUARIO INSERIDO JA SE ENCONTRA NA BASE DE DADOS, CODIFICAR A SENHA INSERIDA E SALVAR OS DADOS CADASTRADO NA BASE DE DADOS */[m
[32m+[m	[32m@PostMapping("/cadastrar")[m
[32m+[m	[32mpublic ResponseEntity<Usuario> Post(@RequestBody Usuario usuario) {[m
[32m+[m		[32mOptional<Usuario> user = usuarioService.CadastrarUsuario(usuario);[m
[32m+[m[41m		[m
[32m+[m		[32mtry {[m
[32m+[m			[32mreturn ResponseEntity.ok(user.get());[m
[32m+[m[41m			[m
[32m+[m		[32m}catch(Exception e) {[m
[32m+[m			[32mreturn ResponseEntity.badRequest().build();[m
[32m+[m[41m			[m
[32m+[m		[32m}[m
[32m+[m[41m		[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/UsuarioRepository.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/UsuarioRepository.java[m
[1mnew file mode 100644[m
[1mindex 0000000..9a1a7ee[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/UsuarioRepository.java[m
[36m@@ -0,0 +1,16 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.repository;[m
[32m+[m
[32m+[m[32mimport java.util.Optional;[m
[32m+[m
[32m+[m[32mimport org.springframework.data.jpa.repository.JpaRepository;[m
[32m+[m[32mimport org.springframework.stereotype.Repository;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Usuario;[m
[32m+[m
[32m+[m[32m@Repository[m
[32m+[m[32mpublic interface UsuarioRepository extends JpaRepository<Usuario, Long>{[m
[32m+[m[41m	[m
[32m+[m	[32m/* PESQUISE PELO NOME DE USUARIO */[m
[32m+[m	[32mpublic Optional<Usuario> findByUsuario(String usuario);[m
[32m+[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/BasicSecurityConfig.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/BasicSecurityConfig.java[m
[1mnew file mode 100644[m
[1mindex 0000000..ce722bd[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/BasicSecurityConfig.java[m
[36m@@ -0,0 +1,51 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.seguranca;[m
[32m+[m
[32m+[m[32mimport org.springframework.beans.factory.annotation.Autowired;[m
[32m+[m[32mimport org.springframework.context.annotation.Bean;[m
[32m+[m[32mimport org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;[m
[32m+[m[32mimport org.springframework.security.config.annotation.web.builders.HttpSecurity;[m
[32m+[m[32mimport org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;[m
[32m+[m[32mimport org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;[m
[32m+[m[32mimport org.springframework.security.config.http.SessionCreationPolicy;[m
[32m+[m[32mimport org.springframework.security.core.userdetails.UserDetailsService;[m
[32m+[m[32mimport org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;[m
[32m+[m[32mimport org.springframework.security.crypto.password.PasswordEncoder;[m
[32m+[m
[32m+[m[32m@EnableWebSecurity[m
[32m+[m[32mpublic class BasicSecurityConfig extends WebSecurityConfigurerAdapter {[m
[32m+[m[41m	[m
[32m+[m	[32m/* ESSA CLASSE VEM DE 'WebSecurityConfigurerAdapter' */[m
[32m+[m	[32m@Autowired[m
[32m+[m	[32mprivate UserDetailsService userDetailsService;[m
[32m+[m[41m	[m
[32m+[m	[32m/* METODO PARA SOBRESCREVER O PADRAO DA CLASSE 'UserDetailsService' */[m
[32m+[m	[32m@Override[m
[32m+[m	[32mprotected void configure(AuthenticationManagerBuilder auth) throws Exception {[m
[32m+[m		[32mauth.userDetailsService(userDetailsService);[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32m@Bean[m
[32m+[m	[32mpublic PasswordEncoder passwordEncoder() {[m
[32m+[m		[32mreturn new BCryptPasswordEncoder();[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32m@Override[m
[32m+[m	[32mprotected void configure(HttpSecurity http) throws Exception {[m
[32m+[m		[32m/* liberar edpoints para poderem ser acessados sem a necessidade de um token */[m
[32m+[m		[32mhttp.authorizeRequests()[m
[32m+[m		[32m.antMatchers("/usuarios/logar").permitAll()[m
[32m+[m		[32m.antMatchers("/usuarios/cadastrar").permitAll()[m
[32m+[m		[32m/* nao deixar acessar os demais endpoints sem estarem com um token */[m
[32m+[m		[32m.anyRequest().authenticated()[m
[32m+[m		[32m/* trabalha com uma seguranca basica */[m
[32m+[m		[32m.and().httpBasic()[m
[32m+[m		[32m.and().sessionManagement()[m
[32m+[m		[32m/* STATELESS -> nao salva a secao */[m
[32m+[m		[32m.sessionCreationPolicy(SessionCreationPolicy.STATELESS)[m
[32m+[m		[32m.and().cors()[m
[32m+[m		[32m/* desabilita as configuracoes padroes */[m
[32m+[m		[32m.and().csrf().disable();[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m
[32m+[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/UserDetailsImplementation.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/UserDetailsImplementation.java[m
[1mnew file mode 100644[m
[1mindex 0000000..c7904b2[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/UserDetailsImplementation.java[m
[36m@@ -0,0 +1,68 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.seguranca;[m
[32m+[m
[32m+[m[32mimport java.util.Collection;[m
[32m+[m[32mimport java.util.List;[m
[32m+[m
[32m+[m[32mimport org.springframework.security.core.GrantedAuthority;[m
[32m+[m[32mimport org.springframework.security.core.userdetails.UserDetails;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Usuario;[m
[32m+[m
[32m+[m[32mpublic class UserDetailsImplementation implements UserDetails {[m
[32m+[m[41m	[m
[32m+[m	[32mprivate static final long serialVersionUID = 1L;[m
[32m+[m
[32m+[m	[32mprivate String userName;[m
[32m+[m	[32mprivate String password;[m
[32m+[m[41m	[m
[32m+[m	[32m/* LEMBRAR DE SEMPRE INSERIR ESSE ATRIBUTO, PARA QUE POSSAMOS TRAZER O SEU VALOR QUANDO FORMOS AUTENTICAR UM USUARIO PARA ACESSAR UMA DETERMIANDA PAGINA DA APLICACA */[m
[32m+[m	[32mprivate List<GrantedAuthority> authorities;[m[41m [m
[32m+[m
[32m+[m	[32mpublic UserDetailsImplementation(Usuario user) {[m
[32m+[m		[32mthis.userName = user.getUsuario();[m
[32m+[m		[32mthis.password = user.getSenha();[m[41m		[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic UserDetailsImplementation() {[m
[32m+[m[41m		[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m/* COMO ESTAMOS IMPLEMENTADNDO UMA CLASSE, DEVEMOS IMPORTAR TODOS OS SEUS METODOS CRIADOS */[m
[32m+[m
[32m+[m	[32m@Override[m
[32m+[m	[32mpublic Collection<? extends GrantedAuthority> getAuthorities() {[m
[32m+[m		[32mreturn authorities;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32m@Override[m
[32m+[m	[32mpublic String getPassword() {[m
[32m+[m		[32mreturn password;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32m@Override[m
[32m+[m	[32mpublic String getUsername() {[m
[32m+[m
[32m+[m		[32mreturn userName;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32m@Override[m
[32m+[m	[32mpublic boolean isAccountNonExpired() {[m
[32m+[m		[32mreturn true;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32m@Override[m
[32m+[m	[32mpublic boolean isAccountNonLocked() {[m
[32m+[m		[32mreturn true;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32m@Override[m
[32m+[m	[32mpublic boolean isCredentialsNonExpired() {[m
[32m+[m		[32mreturn true;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32m@Override[m
[32m+[m	[32mpublic boolean isEnabled() {[m
[32m+[m		[32mreturn true;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/UserDetailsServiceImplementation.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/UserDetailsServiceImplementation.java[m
[1mnew file mode 100644[m
[1mindex 0000000..f325c4e[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/seguranca/UserDetailsServiceImplementation.java[m
[36m@@ -0,0 +1,33 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.seguranca;[m
[32m+[m
[32m+[m[32mimport java.util.Optional;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Usuario;[m
[32m+[m[32mimport com.example.ACSocioambiental.repository.UsuarioRepository;[m
[32m+[m
[32m+[m[32mimport org.springframework.beans.factory.annotation.Autowired;[m
[32m+[m[32mimport org.springframework.security.core.userdetails.UserDetails;[m
[32m+[m[32mimport org.springframework.security.core.userdetails.UserDetailsService;[m
[32m+[m[32mimport org.springframework.security.core.userdetails.UsernameNotFoundException;[m
[32m+[m[32mimport org.springframework.stereotype.Service;[m
[32m+[m
[32m+[m[32m@Service[m
[32m+[m[32mpublic class UserDetailsServiceImplementation implements UserDetailsService {[m
[32m+[m[41m	[m
[32m+[m	[32m@Autowired[m
[32m+[m	[32mprivate UsuarioRepository userRepository;[m
[32m+[m[41m	[m
[32m+[m	[32m@Override[m
[32m+[m	[32mpublic UserDetails loadUserByUsername(String userName) throws UsernameNotFoundException {[m
[32m+[m[41m		[m
[32m+[m		[32m/* PARA VALIDAR O LOGIN, VERIFICAMOS SE O USUARIO CADASTRADOS SE ENCONTRA EM NOSSA BASE DE DADOS */[m
[32m+[m		[32mOptional<Usuario> user = userRepository.findByUsuario(userName);[m
[32m+[m[41m		[m
[32m+[m		[32m/* CASE DE ERRO, INFORMAMOS O USUARIO INSERIDO E INFORMAMOS QUE O MESMO NAO EXISTE EM NOSSA BASE DE DADOS */[m
[32m+[m		[32muser.orElseThrow(() -> new UsernameNotFoundException(userName + " not found."));[m
[32m+[m[41m		[m
[32m+[m		[32m/* CASO O USUARIO ESTAJA CADASTRADO EM NOSSA BASE DE DADOS, RETORNAMOS O LOGIN BEM SUCEDIDO DO USUARIO */[m
[32m+[m		[32mreturn user.map(UserDetailsImplementation::new).get();[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/service/UsuarioService.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/service/UsuarioService.java[m
[1mnew file mode 100644[m
[1mindex 0000000..bee22e2[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/service/UsuarioService.java[m
[36m@@ -0,0 +1,76 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.service;[m
[32m+[m
[32m+[m[32mimport java.nio.charset.Charset;[m
[32m+[m[32mimport java.util.Optional;[m
[32m+[m[32m/*INSERIR MANUALMENTE*/[m
[32m+[m[32mimport org.apache.commons.codec.binary.Base64;[m
[32m+[m
[32m+[m[32mimport org.springframework.beans.factory.annotation.Autowired;[m
[32m+[m[32mimport org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;[m
[32m+[m[32mimport org.springframework.stereotype.Service;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.UserLogin;[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Usuario;[m
[32m+[m[32mimport com.example.ACSocioambiental.repository.UsuarioRepository;[m
[32m+[m
[32m+[m[32m@Service[m
[32m+[m[32mpublic class UsuarioService {[m
[32m+[m[41m	[m
[32m+[m	[32m@Autowired[m
[32m+[m	[32mprivate UsuarioRepository repository;[m
[32m+[m[41m	[m
[32m+[m	[32m/* METODO REPOSAVEL POR CADASTRAR UM USUARIO E ENCRIPTAR SUA SENHA ANTES DE SALVAR NA BASE DE DADOS */[m
[32m+[m	[32mpublic Optional<Usuario> CadastrarUsuario(Usuario usuario) {[m[41m	[m
[32m+[m[41m		[m
[32m+[m		[32m/* CONDICAO PARA INPEDIR A CRIACAO DE UM USUARIO DUPLICADO DENTRO DA APLICACAO */[m
[32m+[m		[32mif(repository.findByUsuario(usuario.getUsuario()).isPresent()) {[m
[32m+[m			[32mreturn null;[m
[32m+[m[41m			[m
[32m+[m		[32m}[m
[32m+[m[41m		[m
[32m+[m		[32m/* CLASSE QUE E RESPOSAVEL POR ENCRIPTAR A SENHA */[m
[32m+[m		[32mBCryptPasswordEncoder encoder = new BCryptPasswordEncoder();[m
[32m+[m[41m		[m
[32m+[m		[32m/* RECEBE NOSSA SENHA, ENCRIPTA SA SENHA E SALVA ELA NOVAMENTE DETRO DE NOSSO ATRIBUTO SENHA */[m
[32m+[m		[32mString senhaEncoder = encoder.encode(usuario.getSenha());[m
[32m+[m		[32musuario.setSenha(senhaEncoder);[m
[32m+[m[41m		[m
[32m+[m		[32m/* RETORNAMOS ESSE DADO ATUALIZADO DENTRO DO NOSSO OBJETO USUARIO */[m
[32m+[m		[32mreturn Optional.of(repository.save(usuario));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m/* METODO RESPOSAVEL POR VALIDAR NOSSSO LOGIN AO ACESSAR A APLICACAO */[m
[32m+[m	[32m/* RECEBEMOS OS DADOS VINDOS DO BODY(O QUE O USUARIO ACABOU DE DIGITAR PARA LOGAR) E ARAMZEMOS ESSES DADOS DENTRO DE NOSSA CLASSE 'UserLogin <- Classe auxiliar'*/[m
[32m+[m	[32mpublic Optional<UserLogin> Logar(Optional<UserLogin> user) {[m
[32m+[m
[32m+[m		[32mBCryptPasswordEncoder encoder = new BCryptPasswordEncoder();[m
[32m+[m		[32mOptional<Usuario> usuario = repository.findByUsuario(user.get().getUsuario());[m
[32m+[m[41m		[m
[32m+[m		[32m/* CASO TENHA ALGUM VALOR DIGITADO, IREMOS COMPARAR OS DADOS QUE ESTAO CADASTRADOS NA BASE DE DADOS COM O QUE O USUARIO ACABOU DE DIGITAR */[m
[32m+[m		[32mif (usuario.isPresent()) {[m
[32m+[m			[32m/* COMPARA O QUE FOI DIGITADO NO BODY COM O QUE ESTA NO BANCO DE DADOS REFERENTE AQUELE DETERMINADO USUARIO */[m
[32m+[m			[32mif (encoder.matches(user.get().getSenha(), usuario.get().getSenha())) {[m
[32m+[m[41m				[m
[32m+[m				[32m/* CRIA UMA STRING COM O 'NOME_USUARIO:SENHA' */[m
[32m+[m				[32mString auth = user.get().getUsuario() + ":" + user.get().getSenha();[m
[32m+[m[41m				[m
[32m+[m				[32m/* CRIA UM ARRAY DE BYTE, QUE RECEBE A STRING GERADA ACIMA E FORMATA NO PADRAO 'US-ASCII' */[m
[32m+[m				[32mbyte[] encodedAuth = Base64.encodeBase64(auth.getBytes(Charset.forName("US-ASCII")));[m
[32m+[m[41m				[m
[32m+[m				[32m/* GERA O TOKEN PARA ACESSO DE USUARIO POR MEIO DO ARRAY DE BY GERADO */[m
[32m+[m				[32mString authHeader = "Basic " + new String(encodedAuth);[m
[32m+[m[41m				[m
[32m+[m				[32m/* INSERE O TOKEN GERADO DENTRO DE NOSSO ATRIBUTO TOKEN */[m
[32m+[m				[32muser.get().setToken(authHeader);[m[41m				[m
[32m+[m				[32muser.get().setNome(usuario.get().getNome());[m
[32m+[m				[32muser.get().setSenha(usuario.get().getSenha());[m
[32m+[m[41m				[m
[32m+[m				[32mreturn user;[m
[32m+[m
[32m+[m			[32m}[m
[32m+[m		[32m}[m
[32m+[m[41m		[m
[32m+[m		[32mreturn null;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/ACSocioambiental/src/main/resources/application.properties b/ACSocioambiental/src/main/resources/application.properties[m
[1mindex a0d6135..64c8aa3 100644[m
[1m--- a/ACSocioambiental/src/main/resources/application.properties[m
[1m+++ b/ACSocioambiental/src/main/resources/application.properties[m
[36m@@ -1,5 +1,5 @@[m
 spring.jpa.hibernate.ddl-auto=update[m
 spring.datasource.url=jdbc:mysql://localhost/sos_humanidade?createDatabaseIfNotExist=true&serverTimezone=UTC&useSSl=false[m
 spring.datasource.username=root[m
[31m-spring.datasource.password=Edkaike1[m
[32m+[m[32mspring.datasource.password=SENHA-BANCO[m
 spring.jpa.show-sql=true[m
\ No newline at end of file[m

[33mcommit b32a29afb08b946bac29f0f209c6685ea66fb6f1[m
Author: Clamant96 <kevin.lazzarotto@hotmail.com>
Date:   Mon Apr 5 11:29:10 2021 -0300

    Construcao de metodos de busca de maior e menor preco, e por produtos ativos ou inativos.

[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java[m
[1mindex 2f2600f..28c33bd 100644[m
[1m--- a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java[m
[36m@@ -39,7 +39,7 @@[m [mpublic class Produto {[m
 	private double preco;[m
 	[m
 	@NotNull[m
[31m-	private boolean ativo ;[m
[32m+[m	[32mprivate boolean ativo;[m
 	[m
 	@ManyToOne[m
 	@JsonIgnoreProperties("produto")[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/ProdutoController.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/ProdutoController.java[m
[1mindex eaf5611..cdf0ac2 100644[m
[1m--- a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/ProdutoController.java[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/ProdutoController.java[m
[36m@@ -46,6 +46,26 @@[m [mpublic class ProdutoController {[m
 		return ResponseEntity.ok(repository.findAllByNomeContainingIgnoreCase(nome));[m
 	}[m
 	[m
[32m+[m	[32m/* TRAS TODOS OS VALORES <= (menores ou igual) CADASTRADOS DENTRO DE SUA TABELA */[m
[32m+[m	[32m@GetMapping("/precoMenor/{preco}")[m
[32m+[m	[32mpublic ResponseEntity<List<Produto>> findByPrecoMenorProduto(@PathVariable int preco){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.findAllByPrecoLessThanEqual(preco));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m/* TRAS TODOS OS VALORES >= (maiores ou igual) CADASTRADOS DENTRO DE SUA TABELA */[m
[32m+[m	[32m@GetMapping("/precoMaior/{preco}")[m
[32m+[m	[32mpublic ResponseEntity<List<Produto>> findByPrecoMaiorProduto(@PathVariable int preco){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.findAllByPrecoGreaterThanEqual(preco));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@GetMapping("/ativo/{ativo}")[m
[32m+[m	[32mpublic ResponseEntity<List<Produto>> findAllByAtivo(@PathVariable boolean ativo){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.findAllByAtivo(ativo));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
 	@PostMapping[m
 	public ResponseEntity<Produto> postProduto(@RequestBody Produto produto){[m
 		[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/ProdutoRepository.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/ProdutoRepository.java[m
[1mindex 9b11236..814290b 100644[m
[1m--- a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/ProdutoRepository.java[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/ProdutoRepository.java[m
[36m@@ -3,6 +3,8 @@[m [mpackage com.example.ACSocioambiental.repository;[m
 import java.util.List;[m
 [m
 import org.springframework.data.jpa.repository.JpaRepository;[m
[32m+[m[32mimport org.springframework.data.jpa.repository.Query;[m
[32m+[m[32mimport org.springframework.data.repository.query.Param;[m
 import org.springframework.stereotype.Repository;[m
 [m
 import com.example.ACSocioambiental.Model.Produto;[m
[36m@@ -11,4 +13,11 @@[m [mimport com.example.ACSocioambiental.Model.Produto;[m
 public interface ProdutoRepository extends JpaRepository<Produto, Long>{[m
 	public List<Produto> findAllByNomeContainingIgnoreCase(String nome);[m
 	[m
[32m+[m	[32mpublic List<Produto> findAllByPrecoLessThanEqual(double preco);[m
[32m+[m[41m	[m
[32m+[m	[32mpublic List<Produto> findAllByPrecoGreaterThanEqual(double preco);[m
[32m+[m[41m	[m
[32m+[m	[32m@Query(value = "SELECT * FROM tb_produto WHERE ativo = :ativo", nativeQuery = true)[m
[32m+[m	[32mpublic List<Produto> findAllByAtivo(@Param("ativo") boolean ativo);[m
[32m+[m[41m	[m
 }[m

[33mcommit dab1660f4e9820c890edd1ab0f076d5f529cf190[m
Author: Clamant96 <kevin.lazzarotto@hotmail.com>
Date:   Thu Mar 25 11:27:53 2021 -0300

    Criacao de repositorio e controller para as classes Categoria e Produto

[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Categoria.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Categoria.java[m
[1mindex 9db6f5d..e34ec3b 100644[m
[1m--- a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Categoria.java[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Categoria.java[m
[36m@@ -12,6 +12,8 @@[m [mimport javax.persistence.Table;[m
 import javax.validation.constraints.NotNull;[m
 import javax.validation.constraints.Size;[m
 [m
[32m+[m[32mimport org.hibernate.validator.constraints.URL;[m
[32m+[m
 import com.fasterxml.jackson.annotation.JsonIgnoreProperties;[m
 [m
 @Entity[m
[36m@@ -20,25 +22,23 @@[m [mpublic class Categoria {[m
 	[m
 	@Id[m
 	@GeneratedValue(strategy = GenerationType.IDENTITY)[m
[31m-	private long id_categoria;[m
[32m+[m	[32mprivate long id;[m
 	[m
 	@NotNull[m
 	@Size(min = 5, max =50)[m
[31m-	private String nome_categoria;[m
[32m+[m	[32mprivate String nome;[m
 	[m
[31m-	@NotNull[m
[31m-	@Size(min=10 , max = 300)[m
[31m-	private String imgem_categoria;[m
[32m+[m	[32m@URL[m
[32m+[m	[32mprivate String imagem;[m
 	[m
 	@NotNull[m
 	@Size(min=5 , max= 200)[m
[31m-	private String descricao_categoria;[m
[32m+[m	[32mprivate String descricao;[m
 	[m
 	@OneToMany(mappedBy = "categoria", cascade = CascadeType.ALL)[m
[31m-	@JsonIgnoreProperties("categoria") // se der erro foi aqui[m
[32m+[m	[32m@JsonIgnoreProperties("categoria")[m
 	private List<Produto> produto;[m
 	[m
[31m-	[m
 	public List<Produto> getProduto() {[m
 		return produto;[m
 	}[m
[36m@@ -47,39 +47,36 @@[m [mpublic class Categoria {[m
 		this.produto = produto;[m
 	}[m
 [m
[31m-	public long getId_categoria() {[m
[31m-		return id_categoria;[m
[32m+[m	[32mpublic long getId() {[m
[32m+[m		[32mreturn id;[m
 	}[m
 [m
[31m-	public void setId_categoria(long id_categoria) {[m
[31m-		this.id_categoria = id_categoria;[m
[32m+[m	[32mpublic void setId(long id) {[m
[32m+[m		[32mthis.id = id;[m
 	}[m
 [m
[31m-	public String getNome_categoria() {[m
[31m-		return nome_categoria;[m
[32m+[m	[32mpublic String getNome() {[m
[32m+[m		[32mreturn nome;[m
 	}[m
 [m
[31m-	public void setNome_categoria(String nome_categoria) {[m
[31m-		this.nome_categoria = nome_categoria;[m
[32m+[m	[32mpublic void setNome(String nome) {[m
[32m+[m		[32mthis.nome = nome;[m
 	}[m
 [m
[31m-	public String getImgem_categoria() {[m
[31m-		return imgem_categoria;[m
[32m+[m	[32mpublic String getDescricao() {[m
[32m+[m		[32mreturn descricao;[m
 	}[m
 [m
[31m-	public void setImgem_categoria(String imgem_categoria) {[m
[31m-		this.imgem_categoria = imgem_categoria;[m
[32m+[m	[32mpublic void setDescricao(String descricao) {[m
[32m+[m		[32mthis.descricao = descricao;[m
 	}[m
 [m
[31m-	public String getDescricao_categoria() {[m
[31m-		return descricao_categoria;[m
[32m+[m	[32mpublic String getImagem() {[m
[32m+[m		[32mreturn imagem;[m
 	}[m
 [m
[31m-	public void setDescricao_categoria(String descricao_categoria) {[m
[31m-		this.descricao_categoria = descricao_categoria;[m
[32m+[m	[32mpublic void setImagem(String imagem) {[m
[32m+[m		[32mthis.imagem = imagem;[m
 	}[m
 	[m
[31m-	[m
[31m-	[m
[31m-	[m
 }[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java[m
[1mindex 80ab937..2f2600f 100644[m
[1m--- a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java[m
[36m@@ -11,47 +11,39 @@[m [mimport javax.persistence.Table;[m
 import javax.validation.constraints.NotNull;[m
 import javax.validation.constraints.Size;[m
 [m
[32m+[m[32mimport org.hibernate.validator.constraints.URL;[m
[32m+[m
 import com.fasterxml.jackson.annotation.JsonIgnoreProperties;[m
 [m
 [m
 @Entity[m
 @Table(name= "tb_produto")[m
 public class Produto {[m
[32m+[m[41m	[m
 	@Id[m
 	@GeneratedValue(strategy = GenerationType.IDENTITY)[m
 	private long id;[m
 	[m
 	@NotNull[m
[31m-	@Size(min =3, max =30)[m
[32m+[m	[32m@Size(max =30)[m
 	public String nome;[m
 	[m
 	@NotNull[m
[31m-	private double preco;[m
[31m-	[m
[31m-	@NotNull[m
[31m-	@Size(min = 5, max= 100)[m
[32m+[m	[32m@Size(max= 500)[m
 	private String descricao;[m
 	[m
[31m-	@NotNull[m
[31m-	@Size(min = 5, max= 300)[m
[31m-	private String imagens;[m
[32m+[m	[32m@URL[m
[32m+[m	[32mprivate String imagem;[m
 	[m
 	@NotNull[m
[31m-	private int qt_produto;[m
[32m+[m	[32mprivate double preco;[m
 	[m
 	@NotNull[m
[31m-	private boolean produto_ativo ;[m
[31m-	[m
[32m+[m	[32mprivate boolean ativo ;[m
 	[m
 	@ManyToOne[m
[31m-	@JsonIgnoreProperties("produto") // se der erro foi aqui[m
[32m+[m	[32m@JsonIgnoreProperties("produto")[m
 	private Categoria categoria;[m
[31m-[m
[31m-	[m
[31m-	[m
[31m-	[m
[31m-	[m
[31m-	[m
 	[m
 	public Categoria getCategoria() {[m
 		return categoria;[m
[36m@@ -93,29 +85,20 @@[m [mpublic class Produto {[m
 		this.descricao = descricao;[m
 	}[m
 [m
[31m-	public String getImagens() {[m
[31m-		return imagens;[m
[32m+[m	[32mpublic String getImagem() {[m
[32m+[m		[32mreturn imagem;[m
 	}[m
 [m
[31m-	public void setImagens(String imagens) {[m
[31m-		this.imagens = imagens;[m
[32m+[m	[32mpublic void setImagem(String imagem) {[m
[32m+[m		[32mthis.imagem = imagem;[m
 	}[m
 [m
[31m-	public int getQt_produto() {[m
[31m-		return qt_produto;[m
[32m+[m	[32mpublic boolean isAtivo() {[m
[32m+[m		[32mreturn ativo;[m
 	}[m
 [m
[31m-	public void setQt_produto(int qt_produto) {[m
[31m-		this.qt_produto = qt_produto;[m
[32m+[m	[32mpublic void setAtivo(boolean ativo) {[m
[32m+[m		[32mthis.ativo = ativo;[m
 	}[m
 [m
[31m-	public boolean isProduto_ativo() {[m
[31m-		return produto_ativo;[m
[31m-	}[m
[31m-[m
[31m-	public void setProduto_ativo(boolean produto_ativo) {[m
[31m-		this.produto_ativo = produto_ativo;[m
[31m-	}[m
[31m-	[m
[31m-	[m
 }[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java[m
[1mindex cdabe9c..0201537 100644[m
[1m--- a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java[m
[36m@@ -6,6 +6,7 @@[m [mimport javax.persistence.GenerationType;[m
 import javax.persistence.Id;[m
 import javax.persistence.Table;[m
 import javax.validation.constraints.NotNull;[m
[32m+[m[32mimport javax.validation.constraints.Size;[m
 [m
 @Entity[m
 @Table(name="tb_usuario")[m
[36m@@ -16,17 +17,17 @@[m [mpublic class Usuario {[m
 	private long id;[m
 	[m
 	@NotNull[m
[32m+[m	[32m@Size(min=1, max=200)[m
 	private String nome;[m
 	[m
 	@NotNull[m
[32m+[m	[32m@Size(min=1, max=200)[m
 	private String email;[m
 	[m
 	@NotNull[m
[32m+[m	[32m@Size(min=1, max=200)[m
 	private String senha ;[m
 	[m
[31m-	[m
[31m-	[m
[31m-[m
 	public long getId() {[m
 		return id;[m
 	}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/CategoriaController.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/CategoriaController.java[m
[1mnew file mode 100644[m
[1mindex 0000000..5f6fc59[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/CategoriaController.java[m
[36m@@ -0,0 +1,67 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.controller;[m
[32m+[m
[32m+[m[32mimport java.util.List;[m
[32m+[m
[32m+[m[32mimport org.springframework.beans.factory.annotation.Autowired;[m
[32m+[m[32mimport org.springframework.http.HttpStatus;[m
[32m+[m[32mimport org.springframework.http.ResponseEntity;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.CrossOrigin;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.DeleteMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.GetMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.PathVariable;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.PostMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.PutMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RequestBody;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RequestMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RestController;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Categoria;[m
[32m+[m[32mimport com.example.ACSocioambiental.repository.CategoriaRepository;[m
[32m+[m
[32m+[m[32m@RestController[m
[32m+[m[32m@RequestMapping("/categorias")[m
[32m+[m[32m@CrossOrigin(origins = "*", allowedHeaders = "*")[m
[32m+[m[32mpublic class CategoriaController {[m
[32m+[m[41m	[m
[32m+[m	[32m@Autowired[m
[32m+[m	[32mprivate CategoriaRepository repository;[m
[32m+[m[41m	[m
[32m+[m	[32m@GetMapping[m
[32m+[m	[32mpublic ResponseEntity<List<Categoria>> findAllCategoria(){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.findAll());[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@GetMapping("/{id}")[m
[32m+[m	[32mpublic ResponseEntity<Categoria> findByIdCategoria(@PathVariable long id){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn repository.findById(id)[m
[32m+[m				[32m.map(resp -> ResponseEntity.ok(resp))[m
[32m+[m				[32m.orElse(ResponseEntity.notFound().build());[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@GetMapping("/nome/{nome}")[m
[32m+[m	[32mpublic ResponseEntity<List<Categoria>> findByNomeCategoria(@PathVariable String nome){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.findAllByNomeContainingIgnoreCase(nome));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@PostMapping[m
[32m+[m	[32mpublic ResponseEntity<Categoria> postCategoria(@RequestBody Categoria categoria){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.status(HttpStatus.CREATED).body(repository.save(categoria));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@PutMapping[m
[32m+[m	[32mpublic ResponseEntity<Categoria> putCategoria(@RequestBody Categoria categoria){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.save(categoria));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@DeleteMapping("/{id}")[m
[32m+[m	[32mpublic void deleteCategoria(@PathVariable long id){[m
[32m+[m[41m		[m
[32m+[m		[32mrepository.deleteById(id);[m
[32m+[m	[32m}[m
[32m+[m[32m}[m
[32m+[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/ProdutoController.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/ProdutoController.java[m
[1mnew file mode 100644[m
[1mindex 0000000..eaf5611[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/controller/ProdutoController.java[m
[36m@@ -0,0 +1,67 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.controller;[m
[32m+[m
[32m+[m[32mimport java.util.List;[m
[32m+[m
[32m+[m[32mimport org.springframework.beans.factory.annotation.Autowired;[m
[32m+[m[32mimport org.springframework.http.HttpStatus;[m
[32m+[m[32mimport org.springframework.http.ResponseEntity;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.CrossOrigin;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.DeleteMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.GetMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.PathVariable;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.PostMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.PutMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RequestBody;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RequestMapping;[m
[32m+[m[32mimport org.springframework.web.bind.annotation.RestController;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Produto;[m
[32m+[m[32mimport com.example.ACSocioambiental.repository.ProdutoRepository;[m
[32m+[m
[32m+[m[32m@RestController[m
[32m+[m[32m@RequestMapping("/produtos")[m
[32m+[m[32m@CrossOrigin(origins = "*")[m
[32m+[m[32mpublic class ProdutoController {[m
[32m+[m[41m	[m
[32m+[m	[32m@Autowired[m
[32m+[m	[32mprivate ProdutoRepository repository;[m
[32m+[m[41m	[m
[32m+[m	[32m@GetMapping[m
[32m+[m	[32mpublic ResponseEntity<List<Produto>> findAllProduto(){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.findAll());[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@GetMapping("/{id}")[m
[32m+[m	[32mpublic ResponseEntity<Produto> findByIdProduto(@PathVariable long id){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn repository.findById(id)[m
[32m+[m				[32m.map(resp -> ResponseEntity.ok(resp))[m
[32m+[m				[32m.orElse(ResponseEntity.notFound().build());[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@GetMapping("/nome/{nome}")[m
[32m+[m	[32mpublic ResponseEntity<List<Produto>> findByNomeProduto(@PathVariable String nome){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.findAllByNomeContainingIgnoreCase(nome));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@PostMapping[m
[32m+[m	[32mpublic ResponseEntity<Produto> postProduto(@RequestBody Produto produto){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.status(HttpStatus.CREATED).body(repository.save(produto));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@PutMapping[m
[32m+[m	[32mpublic ResponseEntity<Produto> putProduto(@RequestBody Produto produto){[m
[32m+[m[41m		[m
[32m+[m		[32mreturn ResponseEntity.ok(repository.save(produto));[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m	[32m@DeleteMapping("/{id}")[m
[32m+[m	[32mpublic void deleteProduto(@PathVariable long id) {[m
[32m+[m[41m		[m
[32m+[m		[32mrepository.deleteById(id);[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/CategoriaRepository.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/CategoriaRepository.java[m
[1mnew file mode 100644[m
[1mindex 0000000..0e3abbc[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/CategoriaRepository.java[m
[36m@@ -0,0 +1,14 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.repository;[m
[32m+[m
[32m+[m[32mimport java.util.List;[m
[32m+[m
[32m+[m[32mimport org.springframework.data.jpa.repository.JpaRepository;[m
[32m+[m[32mimport org.springframework.stereotype.Repository;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Categoria;[m
[32m+[m
[32m+[m[32m@Repository[m
[32m+[m[32mpublic interface CategoriaRepository extends JpaRepository<Categoria, Long>{[m
[32m+[m	[32mpublic List<Categoria> findAllByNomeContainingIgnoreCase(String nome);[m
[32m+[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/ProdutoRepository.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/ProdutoRepository.java[m
[1mnew file mode 100644[m
[1mindex 0000000..9b11236[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/repository/ProdutoRepository.java[m
[36m@@ -0,0 +1,14 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.repository;[m
[32m+[m
[32m+[m[32mimport java.util.List;[m
[32m+[m
[32m+[m[32mimport org.springframework.data.jpa.repository.JpaRepository;[m
[32m+[m[32mimport org.springframework.stereotype.Repository;[m
[32m+[m
[32m+[m[32mimport com.example.ACSocioambiental.Model.Produto;[m
[32m+[m
[32m+[m[32m@Repository[m
[32m+[m[32mpublic interface ProdutoRepository extends JpaRepository<Produto, Long>{[m
[32m+[m	[32mpublic List<Produto> findAllByNomeContainingIgnoreCase(String nome);[m
[32m+[m[41m	[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/resources/application.properties b/ACSocioambiental/src/main/resources/application.properties[m
[1mindex 319369d..a0d6135 100644[m
[1m--- a/ACSocioambiental/src/main/resources/application.properties[m
[1m+++ b/ACSocioambiental/src/main/resources/application.properties[m
[36m@@ -1,5 +1,5 @@[m
 spring.jpa.hibernate.ddl-auto=update[m
 spring.datasource.url=jdbc:mysql://localhost/sos_humanidade?createDatabaseIfNotExist=true&serverTimezone=UTC&useSSl=false[m
 spring.datasource.username=root[m
[31m-spring.datasource.password=123456789[m
[32m+[m[32mspring.datasource.password=Edkaike1[m
 spring.jpa.show-sql=true[m
\ No newline at end of file[m

[33mcommit 9f3cab3223f177608733a55fa1966c0f9ee8bf15[m[33m ([m[1;31morigin/panda[m[33m)[m
Author: Daniel <69875036+Danieloliver11@users.noreply.github.com>
Date:   Mon Mar 22 11:50:47 2021 -0300

    model, categoria, produto e Usuario feitas

[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Categoria.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Categoria.java[m
[1mnew file mode 100644[m
[1mindex 0000000..9db6f5d[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Categoria.java[m
[36m@@ -0,0 +1,85 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.Model;[m
[32m+[m
[32m+[m[32mimport java.util.List;[m
[32m+[m
[32m+[m[32mimport javax.persistence.CascadeType;[m
[32m+[m[32mimport javax.persistence.Entity;[m
[32m+[m[32mimport javax.persistence.GeneratedValue;[m
[32m+[m[32mimport javax.persistence.GenerationType;[m
[32m+[m[32mimport javax.persistence.Id;[m
[32m+[m[32mimport javax.persistence.OneToMany;[m
[32m+[m[32mimport javax.persistence.Table;[m
[32m+[m[32mimport javax.validation.constraints.NotNull;[m
[32m+[m[32mimport javax.validation.constraints.Size;[m
[32m+[m
[32m+[m[32mimport com.fasterxml.jackson.annotation.JsonIgnoreProperties;[m
[32m+[m
[32m+[m[32m@Entity[m
[32m+[m[32m@Table(name = "tb_categoria")[m
[32m+[m[32mpublic class Categoria {[m
[32m+[m[41m	[m
[32m+[m	[32m@Id[m
[32m+[m	[32m@GeneratedValue(strategy = GenerationType.IDENTITY)[m
[32m+[m	[32mprivate long id_categoria;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32m@Size(min = 5, max =50)[m
[32m+[m	[32mprivate String nome_categoria;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32m@Size(min=10 , max = 300)[m
[32m+[m	[32mprivate String imgem_categoria;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32m@Size(min=5 , max= 200)[m
[32m+[m	[32mprivate String descricao_categoria;[m
[32m+[m[41m	[m
[32m+[m	[32m@OneToMany(mappedBy = "categoria", cascade = CascadeType.ALL)[m
[32m+[m	[32m@JsonIgnoreProperties("categoria") // se der erro foi aqui[m
[32m+[m	[32mprivate List<Produto> produto;[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m	[32mpublic List<Produto> getProduto() {[m
[32m+[m		[32mreturn produto;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setProduto(List<Produto> produto) {[m
[32m+[m		[32mthis.produto = produto;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic long getId_categoria() {[m
[32m+[m		[32mreturn id_categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setId_categoria(long id_categoria) {[m
[32m+[m		[32mthis.id_categoria = id_categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getNome_categoria() {[m
[32m+[m		[32mreturn nome_categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setNome_categoria(String nome_categoria) {[m
[32m+[m		[32mthis.nome_categoria = nome_categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getImgem_categoria() {[m
[32m+[m		[32mreturn imgem_categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setImgem_categoria(String imgem_categoria) {[m
[32m+[m		[32mthis.imgem_categoria = imgem_categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getDescricao_categoria() {[m
[32m+[m		[32mreturn descricao_categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setDescricao_categoria(String descricao_categoria) {[m
[32m+[m		[32mthis.descricao_categoria = descricao_categoria;[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java[m
[1mnew file mode 100644[m
[1mindex 0000000..80ab937[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Produto.java[m
[36m@@ -0,0 +1,121 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.Model;[m
[32m+[m
[32m+[m
[32m+[m
[32m+[m[32mimport javax.persistence.Entity;[m
[32m+[m[32mimport javax.persistence.GeneratedValue;[m
[32m+[m[32mimport javax.persistence.GenerationType;[m
[32m+[m[32mimport javax.persistence.Id;[m
[32m+[m[32mimport javax.persistence.ManyToOne;[m
[32m+[m[32mimport javax.persistence.Table;[m
[32m+[m[32mimport javax.validation.constraints.NotNull;[m
[32m+[m[32mimport javax.validation.constraints.Size;[m
[32m+[m
[32m+[m[32mimport com.fasterxml.jackson.annotation.JsonIgnoreProperties;[m
[32m+[m
[32m+[m
[32m+[m[32m@Entity[m
[32m+[m[32m@Table(name= "tb_produto")[m
[32m+[m[32mpublic class Produto {[m
[32m+[m	[32m@Id[m
[32m+[m	[32m@GeneratedValue(strategy = GenerationType.IDENTITY)[m
[32m+[m	[32mprivate long id;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32m@Size(min =3, max =30)[m
[32m+[m	[32mpublic String nome;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32mprivate double preco;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32m@Size(min = 5, max= 100)[m
[32m+[m	[32mprivate String descricao;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32m@Size(min = 5, max= 300)[m
[32m+[m	[32mprivate String imagens;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32mprivate int qt_produto;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32mprivate boolean produto_ativo ;[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m	[32m@ManyToOne[m
[32m+[m	[32m@JsonIgnoreProperties("produto") // se der erro foi aqui[m
[32m+[m	[32mprivate Categoria categoria;[m
[32m+[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m	[32mpublic Categoria getCategoria() {[m
[32m+[m		[32mreturn categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setCategoria(Categoria categoria) {[m
[32m+[m		[32mthis.categoria = categoria;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic long getId() {[m
[32m+[m		[32mreturn id;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setId(long id) {[m
[32m+[m		[32mthis.id = id;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getNome() {[m
[32m+[m		[32mreturn nome;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setNome(String nome) {[m
[32m+[m		[32mthis.nome = nome;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic double getPreco() {[m
[32m+[m		[32mreturn preco;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setPreco(double preco) {[m
[32m+[m		[32mthis.preco = preco;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getDescricao() {[m
[32m+[m		[32mreturn descricao;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setDescricao(String descricao) {[m
[32m+[m		[32mthis.descricao = descricao;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getImagens() {[m
[32m+[m		[32mreturn imagens;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setImagens(String imagens) {[m
[32m+[m		[32mthis.imagens = imagens;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic int getQt_produto() {[m
[32m+[m		[32mreturn qt_produto;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setQt_produto(int qt_produto) {[m
[32m+[m		[32mthis.qt_produto = qt_produto;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic boolean isProduto_ativo() {[m
[32m+[m		[32mreturn produto_ativo;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setProduto_ativo(boolean produto_ativo) {[m
[32m+[m		[32mthis.produto_ativo = produto_ativo;[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java[m
[1mnew file mode 100644[m
[1mindex 0000000..cdabe9c[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/Model/Usuario.java[m
[36m@@ -0,0 +1,63 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental.Model;[m
[32m+[m
[32m+[m[32mimport javax.persistence.Entity;[m
[32m+[m[32mimport javax.persistence.GeneratedValue;[m
[32m+[m[32mimport javax.persistence.GenerationType;[m
[32m+[m[32mimport javax.persistence.Id;[m
[32m+[m[32mimport javax.persistence.Table;[m
[32m+[m[32mimport javax.validation.constraints.NotNull;[m
[32m+[m
[32m+[m[32m@Entity[m
[32m+[m[32m@Table(name="tb_usuario")[m
[32m+[m[32mpublic class Usuario {[m
[32m+[m[41m	[m
[32m+[m	[32m@Id[m
[32m+[m	[32m@GeneratedValue(strategy = GenerationType.IDENTITY )[m
[32m+[m	[32mprivate long id;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32mprivate String nome;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32mprivate String email;[m
[32m+[m[41m	[m
[32m+[m	[32m@NotNull[m
[32m+[m	[32mprivate String senha ;[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m
[32m+[m	[32mpublic long getId() {[m
[32m+[m		[32mreturn id;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setId(long id) {[m
[32m+[m		[32mthis.id = id;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getNome() {[m
[32m+[m		[32mreturn nome;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setNome(String nome) {[m
[32m+[m		[32mthis.nome = nome;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getEmail() {[m
[32m+[m		[32mreturn email;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setEmail(String email) {[m
[32m+[m		[32mthis.email = email;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic String getSenha() {[m
[32m+[m		[32mreturn senha;[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m	[32mpublic void setSenha(String senha) {[m
[32m+[m		[32mthis.senha = senha;[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m[41m	[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/resources/application.properties b/ACSocioambiental/src/main/resources/application.properties[m
[1mindex 8b13789..319369d 100644[m
[1m--- a/ACSocioambiental/src/main/resources/application.properties[m
[1m+++ b/ACSocioambiental/src/main/resources/application.properties[m
[36m@@ -1 +1,5 @@[m
[31m-[m
[32m+[m[32mspring.jpa.hibernate.ddl-auto=update[m
[32m+[m[32mspring.datasource.url=jdbc:mysql://localhost/sos_humanidade?createDatabaseIfNotExist=true&serverTimezone=UTC&useSSl=false[m
[32m+[m[32mspring.datasource.username=root[m
[32m+[m[32mspring.datasource.password=123456789[m
[32m+[m[32mspring.jpa.show-sql=true[m
\ No newline at end of file[m

[33mcommit fdf1d0f40ca7aa578923522aa35e204f2abaf501[m[33m ([m[1;31morigin/main[m[33m, [m[1;31morigin/gustavo[m[33m, [m[1;31morigin/HEAD[m[33m)[m
Merge: c4b1ca5 2778c7d
Author: Daniel <69875036+Danieloliver11@users.noreply.github.com>
Date:   Mon Mar 22 10:00:59 2021 -0300

    Merge branch 'main' of https://github.com/Danieloliver11/S.O.S-HUMANIDADE- into main

[33mcommit c4b1ca5f87caff6f259ffbfdcf238e795b3393b6[m
Author: Daniel <69875036+Danieloliver11@users.noreply.github.com>
Date:   Mon Mar 22 10:00:07 2021 -0300

    beginning

[1mdiff --git a/ACSocioambiental.zip b/ACSocioambiental.zip[m
[1mnew file mode 100644[m
[1mindex 0000000..761c78e[m
Binary files /dev/null and b/ACSocioambiental.zip differ
[1mdiff --git a/ACSocioambiental/.gitignore b/ACSocioambiental/.gitignore[m
[1mnew file mode 100644[m
[1mindex 0000000..549e00a[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/.gitignore[m
[36m@@ -0,0 +1,33 @@[m
[32m+[m[32mHELP.md[m
[32m+[m[32mtarget/[m
[32m+[m[32m!.mvn/wrapper/maven-wrapper.jar[m
[32m+[m[32m!**/src/main/**/target/[m
[32m+[m[32m!**/src/test/**/target/[m
[32m+[m
[32m+[m[32m### STS ###[m
[32m+[m[32m.apt_generated[m
[32m+[m[32m.classpath[m
[32m+[m[32m.factorypath[m
[32m+[m[32m.project[m
[32m+[m[32m.settings[m
[32m+[m[32m.springBeans[m
[32m+[m[32m.sts4-cache[m
[32m+[m
[32m+[m[32m### IntelliJ IDEA ###[m
[32m+[m[32m.idea[m
[32m+[m[32m*.iws[m
[32m+[m[32m*.iml[m
[32m+[m[32m*.ipr[m
[32m+[m
[32m+[m[32m### NetBeans ###[m
[32m+[m[32m/nbproject/private/[m
[32m+[m[32m/nbbuild/[m
[32m+[m[32m/dist/[m
[32m+[m[32m/nbdist/[m
[32m+[m[32m/.nb-gradle/[m
[32m+[m[32mbuild/[m
[32m+[m[32m!**/src/main/**/build/[m
[32m+[m[32m!**/src/test/**/build/[m
[32m+[m
[32m+[m[32m### VS Code ###[m
[32m+[m[32m.vscode/[m
[1mdiff --git a/ACSocioambiental/.mvn/wrapper/MavenWrapperDownloader.java b/ACSocioambiental/.mvn/wrapper/MavenWrapperDownloader.java[m
[1mnew file mode 100644[m
[1mindex 0000000..e76d1f3[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/.mvn/wrapper/MavenWrapperDownloader.java[m
[36m@@ -0,0 +1,117 @@[m
[32m+[m[32m/*[m
[32m+[m[32m * Copyright 2007-present the original author or authors.[m
[32m+[m[32m *[m
[32m+[m[32m * Licensed under the Apache License, Version 2.0 (the "License");[m
[32m+[m[32m * you may not use this file except in compliance with the License.[m
[32m+[m[32m * You may obtain a copy of the License at[m
[32m+[m[32m *[m
[32m+[m[32m *      https://www.apache.org/licenses/LICENSE-2.0[m
[32m+[m[32m *[m
[32m+[m[32m * Unless required by applicable law or agreed to in writing, software[m
[32m+[m[32m * distributed under the License is distributed on an "AS IS" BASIS,[m
[32m+[m[32m * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.[m
[32m+[m[32m * See the License for the specific language governing permissions and[m
[32m+[m[32m * limitations under the License.[m
[32m+[m[32m */[m
[32m+[m[32mimport java.net.*;[m
[32m+[m[32mimport java.io.*;[m
[32m+[m[32mimport java.nio.channels.*;[m
[32m+[m[32mimport java.util.Properties;[m
[32m+[m
[32m+[m[32mpublic class MavenWrapperDownloader {[m
[32m+[m
[32m+[m[32m    private static final String WRAPPER_VERSION = "0.5.6";[m
[32m+[m[32m    /**[m
[32m+[m[32m     * Default URL to download the maven-wrapper.jar from, if no 'downloadUrl' is provided.[m
[32m+[m[32m     */[m
[32m+[m[32m    private static final String DEFAULT_DOWNLOAD_URL = "https://repo.maven.apache.org/maven2/io/takari/maven-wrapper/"[m
[32m+[m[32m        + WRAPPER_VERSION + "/maven-wrapper-" + WRAPPER_VERSION + ".jar";[m
[32m+[m
[32m+[m[32m    /**[m
[32m+[m[32m     * Path to the maven-wrapper.properties file, which might contain a downloadUrl property to[m
[32m+[m[32m     * use instead of the default one.[m
[32m+[m[32m     */[m
[32m+[m[32m    private static final String MAVEN_WRAPPER_PROPERTIES_PATH =[m
[32m+[m[32m            ".mvn/wrapper/maven-wrapper.properties";[m
[32m+[m
[32m+[m[32m    /**[m
[32m+[m[32m     * Path where the maven-wrapper.jar will be saved to.[m
[32m+[m[32m     */[m
[32m+[m[32m    private static final String MAVEN_WRAPPER_JAR_PATH =[m
[32m+[m[32m            ".mvn/wrapper/maven-wrapper.jar";[m
[32m+[m
[32m+[m[32m    /**[m
[32m+[m[32m     * Name of the property which should be used to override the default download url for the wrapper.[m
[32m+[m[32m     */[m
[32m+[m[32m    private static final String PROPERTY_NAME_WRAPPER_URL = "wrapperUrl";[m
[32m+[m
[32m+[m[32m    public static void main(String args[]) {[m
[32m+[m[32m        System.out.println("- Downloader started");[m
[32m+[m[32m        File baseDirectory = new File(args[0]);[m
[32m+[m[32m        System.out.println("- Using base directory: " + baseDirectory.getAbsolutePath());[m
[32m+[m
[32m+[m[32m        // If the maven-wrapper.properties exists, read it and check if it contains a custom[m
[32m+[m[32m        // wrapperUrl parameter.[m
[32m+[m[32m        File mavenWrapperPropertyFile = new File(baseDirectory, MAVEN_WRAPPER_PROPERTIES_PATH);[m
[32m+[m[32m        String url = DEFAULT_DOWNLOAD_URL;[m
[32m+[m[32m        if(mavenWrapperPropertyFile.exists()) {[m
[32m+[m[32m            FileInputStream mavenWrapperPropertyFileInputStream = null;[m
[32m+[m[32m            try {[m
[32m+[m[32m                mavenWrapperPropertyFileInputStream = new FileInputStream(mavenWrapperPropertyFile);[m
[32m+[m[32m                Properties mavenWrapperProperties = new Properties();[m
[32m+[m[32m                mavenWrapperProperties.load(mavenWrapperPropertyFileInputStream);[m
[32m+[m[32m                url = mavenWrapperProperties.getProperty(PROPERTY_NAME_WRAPPER_URL, url);[m
[32m+[m[32m            } catch (IOException e) {[m
[32m+[m[32m                System.out.println("- ERROR loading '" + MAVEN_WRAPPER_PROPERTIES_PATH + "'");[m
[32m+[m[32m            } finally {[m
[32m+[m[32m                try {[m
[32m+[m[32m                    if(mavenWrapperPropertyFileInputStream != null) {[m
[32m+[m[32m                        mavenWrapperPropertyFileInputStream.close();[m
[32m+[m[32m                    }[m
[32m+[m[32m                } catch (IOException e) {[m
[32m+[m[32m                    // Ignore ...[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m[32m        System.out.println("- Downloading from: " + url);[m
[32m+[m
[32m+[m[32m        File outputFile = new File(baseDirectory.getAbsolutePath(), MAVEN_WRAPPER_JAR_PATH);[m
[32m+[m[32m        if(!outputFile.getParentFile().exists()) {[m
[32m+[m[32m            if(!outputFile.getParentFile().mkdirs()) {[m
[32m+[m[32m                System.out.println([m
[32m+[m[32m                        "- ERROR creating output directory '" + outputFile.getParentFile().getAbsolutePath() + "'");[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m[32m        System.out.println("- Downloading to: " + outputFile.getAbsolutePath());[m
[32m+[m[32m        try {[m
[32m+[m[32m            downloadFileFromURL(url, outputFile);[m
[32m+[m[32m            System.out.println("Done");[m
[32m+[m[32m            System.exit(0);[m
[32m+[m[32m        } catch (Throwable e) {[m
[32m+[m[32m            System.out.println("- Error downloading");[m
[32m+[m[32m            e.printStackTrace();[m
[32m+[m[32m            System.exit(1);[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    private static void downloadFileFromURL(String urlString, File destination) throws Exception {[m
[32m+[m[32m        if (System.getenv("MVNW_USERNAME") != null && System.getenv("MVNW_PASSWORD") != null) {[m
[32m+[m[32m            String username = System.getenv("MVNW_USERNAME");[m
[32m+[m[32m            char[] password = System.getenv("MVNW_PASSWORD").toCharArray();[m
[32m+[m[32m            Authenticator.setDefault(new Authenticator() {[m
[32m+[m[32m                @Override[m
[32m+[m[32m                protected PasswordAuthentication getPasswordAuthentication() {[m
[32m+[m[32m                    return new PasswordAuthentication(username, password);[m
[32m+[m[32m                }[m
[32m+[m[32m            });[m
[32m+[m[32m        }[m
[32m+[m[32m        URL website = new URL(urlString);[m
[32m+[m[32m        ReadableByteChannel rbc;[m
[32m+[m[32m        rbc = Channels.newChannel(website.openStream());[m
[32m+[m[32m        FileOutputStream fos = new FileOutputStream(destination);[m
[32m+[m[32m        fos.getChannel().transferFrom(rbc, 0, Long.MAX_VALUE);[m
[32m+[m[32m        fos.close();[m
[32m+[m[32m        rbc.close();[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/.mvn/wrapper/maven-wrapper.jar b/ACSocioambiental/.mvn/wrapper/maven-wrapper.jar[m
[1mnew file mode 100644[m
[1mindex 0000000..2cc7d4a[m
Binary files /dev/null and b/ACSocioambiental/.mvn/wrapper/maven-wrapper.jar differ
[1mdiff --git a/ACSocioambiental/.mvn/wrapper/maven-wrapper.properties b/ACSocioambiental/.mvn/wrapper/maven-wrapper.properties[m
[1mnew file mode 100644[m
[1mindex 0000000..642d572[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/.mvn/wrapper/maven-wrapper.properties[m
[36m@@ -0,0 +1,2 @@[m
[32m+[m[32mdistributionUrl=https://repo.maven.apache.org/maven2/org/apache/maven/apache-maven/3.6.3/apache-maven-3.6.3-bin.zip[m
[32m+[m[32mwrapperUrl=https://repo.maven.apache.org/maven2/io/takari/maven-wrapper/0.5.6/maven-wrapper-0.5.6.jar[m
[1mdiff --git a/ACSocioambiental/mvnw b/ACSocioambiental/mvnw[m
[1mnew file mode 100644[m
[1mindex 0000000..a16b543[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/mvnw[m
[36m@@ -0,0 +1,310 @@[m
[32m+[m[32m#!/bin/sh[m
[32m+[m[32m# ----------------------------------------------------------------------------[m
[32m+[m[32m# Licensed to the Apache Software Foundation (ASF) under one[m
[32m+[m[32m# or more contributor license agreements.  See the NOTICE file[m
[32m+[m[32m# distributed with this work for additional information[m
[32m+[m[32m# regarding copyright ownership.  The ASF licenses this file[m
[32m+[m[32m# to you under the Apache License, Version 2.0 (the[m
[32m+[m[32m# "License"); you may not use this file except in compliance[m
[32m+[m[32m# with the License.  You may obtain a copy of the License at[m
[32m+[m[32m#[m
[32m+[m[32m#    https://www.apache.org/licenses/LICENSE-2.0[m
[32m+[m[32m#[m
[32m+[m[32m# Unless required by applicable law or agreed to in writing,[m
[32m+[m[32m# software distributed under the License is distributed on an[m
[32m+[m[32m# "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY[m
[32m+[m[32m# KIND, either express or implied.  See the License for the[m
[32m+[m[32m# specific language governing permissions and limitations[m
[32m+[m[32m# under the License.[m
[32m+[m[32m# ----------------------------------------------------------------------------[m
[32m+[m
[32m+[m[32m# ----------------------------------------------------------------------------[m
[32m+[m[32m# Maven Start Up Batch script[m
[32m+[m[32m#[m
[32m+[m[32m# Required ENV vars:[m
[32m+[m[32m# ------------------[m
[32m+[m[32m#   JAVA_HOME - location of a JDK home dir[m
[32m+[m[32m#[m
[32m+[m[32m# Optional ENV vars[m
[32m+[m[32m# -----------------[m
[32m+[m[32m#   M2_HOME - location of maven2's installed home dir[m
[32m+[m[32m#   MAVEN_OPTS - parameters passed to the Java VM when running Maven[m
[32m+[m[32m#     e.g. to debug Maven itself, use[m
[32m+[m[32m#       set MAVEN_OPTS=-Xdebug -Xrunjdwp:transport=dt_socket,server=y,suspend=y,address=8000[m
[32m+[m[32m#   MAVEN_SKIP_RC - flag to disable loading of mavenrc files[m
[32m+[m[32m# ----------------------------------------------------------------------------[m
[32m+[m
[32m+[m[32mif [ -z "$MAVEN_SKIP_RC" ] ; then[m
[32m+[m
[32m+[m[32m  if [ -f /etc/mavenrc ] ; then[m
[32m+[m[32m    . /etc/mavenrc[m
[32m+[m[32m  fi[m
[32m+[m
[32m+[m[32m  if [ -f "$HOME/.mavenrc" ] ; then[m
[32m+[m[32m    . "$HOME/.mavenrc"[m
[32m+[m[32m  fi[m
[32m+[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32m# OS specific support.  $var _must_ be set to either true or false.[m
[32m+[m[32mcygwin=false;[m
[32m+[m[32mdarwin=false;[m
[32m+[m[32mmingw=false[m
[32m+[m[32mcase "`uname`" in[m
[32m+[m[32m  CYGWIN*) cygwin=true ;;[m
[32m+[m[32m  MINGW*) mingw=true;;[m
[32m+[m[32m  Darwin*) darwin=true[m
[32m+[m[32m    # Use /usr/libexec/java_home if available, otherwise fall back to /Library/Java/Home[m
[32m+[m[32m    # See https://developer.apple.com/library/mac/qa/qa1170/_index.html[m
[32m+[m[32m    if [ -z "$JAVA_HOME" ]; then[m
[32m+[m[32m      if [ -x "/usr/libexec/java_home" ]; then[m
[32m+[m[32m        export JAVA_HOME="`/usr/libexec/java_home`"[m
[32m+[m[32m      else[m
[32m+[m[32m        export JAVA_HOME="/Library/Java/Home"[m
[32m+[m[32m      fi[m
[32m+[m[32m    fi[m
[32m+[m[32m    ;;[m
[32m+[m[32mesac[m
[32m+[m
[32m+[m[32mif [ -z "$JAVA_HOME" ] ; then[m
[32m+[m[32m  if [ -r /etc/gentoo-release ] ; then[m
[32m+[m[32m    JAVA_HOME=`java-config --jre-home`[m
[32m+[m[32m  fi[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32mif [ -z "$M2_HOME" ] ; then[m
[32m+[m[32m  ## resolve links - $0 may be a link to maven's home[m
[32m+[m[32m  PRG="$0"[m
[32m+[m
[32m+[m[32m  # need this for relative symlinks[m
[32m+[m[32m  while [ -h "$PRG" ] ; do[m
[32m+[m[32m    ls=`ls -ld "$PRG"`[m
[32m+[m[32m    link=`expr "$ls" : '.*-> \(.*\)$'`[m
[32m+[m[32m    if expr "$link" : '/.*' > /dev/null; then[m
[32m+[m[32m      PRG="$link"[m
[32m+[m[32m    else[m
[32m+[m[32m      PRG="`dirname "$PRG"`/$link"[m
[32m+[m[32m    fi[m
[32m+[m[32m  done[m
[32m+[m
[32m+[m[32m  saveddir=`pwd`[m
[32m+[m
[32m+[m[32m  M2_HOME=`dirname "$PRG"`/..[m
[32m+[m
[32m+[m[32m  # make it fully qualified[m
[32m+[m[32m  M2_HOME=`cd "$M2_HOME" && pwd`[m
[32m+[m
[32m+[m[32m  cd "$saveddir"[m
[32m+[m[32m  # echo Using m2 at $M2_HOME[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32m# For Cygwin, ensure paths are in UNIX format before anything is touched[m
[32m+[m[32mif $cygwin ; then[m
[32m+[m[32m  [ -n "$M2_HOME" ] &&[m
[32m+[m[32m    M2_HOME=`cygpath --unix "$M2_HOME"`[m
[32m+[m[32m  [ -n "$JAVA_HOME" ] &&[m
[32m+[m[32m    JAVA_HOME=`cygpath --unix "$JAVA_HOME"`[m
[32m+[m[32m  [ -n "$CLASSPATH" ] &&[m
[32m+[m[32m    CLASSPATH=`cygpath --path --unix "$CLASSPATH"`[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32m# For Mingw, ensure paths are in UNIX format before anything is touched[m
[32m+[m[32mif $mingw ; then[m
[32m+[m[32m  [ -n "$M2_HOME" ] &&[m
[32m+[m[32m    M2_HOME="`(cd "$M2_HOME"; pwd)`"[m
[32m+[m[32m  [ -n "$JAVA_HOME" ] &&[m
[32m+[m[32m    JAVA_HOME="`(cd "$JAVA_HOME"; pwd)`"[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32mif [ -z "$JAVA_HOME" ]; then[m
[32m+[m[32m  javaExecutable="`which javac`"[m
[32m+[m[32m  if [ -n "$javaExecutable" ] && ! [ "`expr \"$javaExecutable\" : '\([^ ]*\)'`" = "no" ]; then[m
[32m+[m[32m    # readlink(1) is not available as standard on Solaris 10.[m
[32m+[m[32m    readLink=`which readlink`[m
[32m+[m[32m    if [ ! `expr "$readLink" : '\([^ ]*\)'` = "no" ]; then[m
[32m+[m[32m      if $darwin ; then[m
[32m+[m[32m        javaHome="`dirname \"$javaExecutable\"`"[m
[32m+[m[32m        javaExecutable="`cd \"$javaHome\" && pwd -P`/javac"[m
[32m+[m[32m      else[m
[32m+[m[32m        javaExecutable="`readlink -f \"$javaExecutable\"`"[m
[32m+[m[32m      fi[m
[32m+[m[32m      javaHome="`dirname \"$javaExecutable\"`"[m
[32m+[m[32m      javaHome=`expr "$javaHome" : '\(.*\)/bin'`[m
[32m+[m[32m      JAVA_HOME="$javaHome"[m
[32m+[m[32m      export JAVA_HOME[m
[32m+[m[32m    fi[m
[32m+[m[32m  fi[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32mif [ -z "$JAVACMD" ] ; then[m
[32m+[m[32m  if [ -n "$JAVA_HOME"  ] ; then[m
[32m+[m[32m    if [ -x "$JAVA_HOME/jre/sh/java" ] ; then[m
[32m+[m[32m      # IBM's JDK on AIX uses strange locations for the executables[m
[32m+[m[32m      JAVACMD="$JAVA_HOME/jre/sh/java"[m
[32m+[m[32m    else[m
[32m+[m[32m      JAVACMD="$JAVA_HOME/bin/java"[m
[32m+[m[32m    fi[m
[32m+[m[32m  else[m
[32m+[m[32m    JAVACMD="`which java`"[m
[32m+[m[32m  fi[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32mif [ ! -x "$JAVACMD" ] ; then[m
[32m+[m[32m  echo "Error: JAVA_HOME is not defined correctly." >&2[m
[32m+[m[32m  echo "  We cannot execute $JAVACMD" >&2[m
[32m+[m[32m  exit 1[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32mif [ -z "$JAVA_HOME" ] ; then[m
[32m+[m[32m  echo "Warning: JAVA_HOME environment variable is not set."[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32mCLASSWORLDS_LAUNCHER=org.codehaus.plexus.classworlds.launcher.Launcher[m
[32m+[m
[32m+[m[32m# traverses directory structure from process work directory to filesystem root[m
[32m+[m[32m# first directory with .mvn subdirectory is considered project base directory[m
[32m+[m[32mfind_maven_basedir() {[m
[32m+[m
[32m+[m[32m  if [ -z "$1" ][m
[32m+[m[32m  then[m
[32m+[m[32m    echo "Path not specified to find_maven_basedir"[m
[32m+[m[32m    return 1[m
[32m+[m[32m  fi[m
[32m+[m
[32m+[m[32m  basedir="$1"[m
[32m+[m[32m  wdir="$1"[m
[32m+[m[32m  while [ "$wdir" != '/' ] ; do[m
[32m+[m[32m    if [ -d "$wdir"/.mvn ] ; then[m
[32m+[m[32m      basedir=$wdir[m
[32m+[m[32m      break[m
[32m+[m[32m    fi[m
[32m+[m[32m    # workaround for JBEAP-8937 (on Solaris 10/Sparc)[m
[32m+[m[32m    if [ -d "${wdir}" ]; then[m
[32m+[m[32m      wdir=`cd "$wdir/.."; pwd`[m
[32m+[m[32m    fi[m
[32m+[m[32m    # end of workaround[m
[32m+[m[32m  done[m
[32m+[m[32m  echo "${basedir}"[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m# concatenates all lines of a file[m
[32m+[m[32mconcat_lines() {[m
[32m+[m[32m  if [ -f "$1" ]; then[m
[32m+[m[32m    echo "$(tr -s '\n' ' ' < "$1")"[m
[32m+[m[32m  fi[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mBASE_DIR=`find_maven_basedir "$(pwd)"`[m
[32m+[m[32mif [ -z "$BASE_DIR" ]; then[m
[32m+[m[32m  exit 1;[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32m##########################################################################################[m
[32m+[m[32m# Extension to allow automatically downloading the maven-wrapper.jar from Maven-central[m
[32m+[m[32m# This allows using the maven wrapper in projects that prohibit checking in binary data.[m
[32m+[m[32m##########################################################################################[m
[32m+[m[32mif [ -r "$BASE_DIR/.mvn/wrapper/maven-wrapper.jar" ]; then[m
[32m+[m[32m    if [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m      echo "Found .mvn/wrapper/maven-wrapper.jar"[m
[32m+[m[32m    fi[m
[32m+[m[32melse[m
[32m+[m[32m    if [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m      echo "Couldn't find .mvn/wrapper/maven-wrapper.jar, downloading it ..."[m
[32m+[m[32m    fi[m
[32m+[m[32m    if [ -n "$MVNW_REPOURL" ]; then[m
[32m+[m[32m      jarUrl="$MVNW_REPOURL/io/takari/maven-wrapper/0.5.6/maven-wrapper-0.5.6.jar"[m
[32m+[m[32m    else[m
[32m+[m[32m      jarUrl="https://repo.maven.apache.org/maven2/io/takari/maven-wrapper/0.5.6/maven-wrapper-0.5.6.jar"[m
[32m+[m[32m    fi[m
[32m+[m[32m    while IFS="=" read key value; do[m
[32m+[m[32m      case "$key" in (wrapperUrl) jarUrl="$value"; break ;;[m
[32m+[m[32m      esac[m
[32m+[m[32m    done < "$BASE_DIR/.mvn/wrapper/maven-wrapper.properties"[m
[32m+[m[32m    if [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m      echo "Downloading from: $jarUrl"[m
[32m+[m[32m    fi[m
[32m+[m[32m    wrapperJarPath="$BASE_DIR/.mvn/wrapper/maven-wrapper.jar"[m
[32m+[m[32m    if $cygwin; then[m
[32m+[m[32m      wrapperJarPath=`cygpath --path --windows "$wrapperJarPath"`[m
[32m+[m[32m    fi[m
[32m+[m
[32m+[m[32m    if command -v wget > /dev/null; then[m
[32m+[m[32m        if [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m          echo "Found wget ... using wget"[m
[32m+[m[32m        fi[m
[32m+[m[32m        if [ -z "$MVNW_USERNAME" ] || [ -z "$MVNW_PASSWORD" ]; then[m
[32m+[m[32m            wget "$jarUrl" -O "$wrapperJarPath"[m
[32m+[m[32m        else[m
[32m+[m[32m            wget --http-user=$MVNW_USERNAME --http-password=$MVNW_PASSWORD "$jarUrl" -O "$wrapperJarPath"[m
[32m+[m[32m        fi[m
[32m+[m[32m    elif command -v curl > /dev/null; then[m
[32m+[m[32m        if [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m          echo "Found curl ... using curl"[m
[32m+[m[32m        fi[m
[32m+[m[32m        if [ -z "$MVNW_USERNAME" ] || [ -z "$MVNW_PASSWORD" ]; then[m
[32m+[m[32m            curl -o "$wrapperJarPath" "$jarUrl" -f[m
[32m+[m[32m        else[m
[32m+[m[32m            curl --user $MVNW_USERNAME:$MVNW_PASSWORD -o "$wrapperJarPath" "$jarUrl" -f[m
[32m+[m[32m        fi[m
[32m+[m
[32m+[m[32m    else[m
[32m+[m[32m        if [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m          echo "Falling back to using Java to download"[m
[32m+[m[32m        fi[m
[32m+[m[32m        javaClass="$BASE_DIR/.mvn/wrapper/MavenWrapperDownloader.java"[m
[32m+[m[32m        # For Cygwin, switch paths to Windows format before running javac[m
[32m+[m[32m        if $cygwin; then[m
[32m+[m[32m          javaClass=`cygpath --path --windows "$javaClass"`[m
[32m+[m[32m        fi[m
[32m+[m[32m        if [ -e "$javaClass" ]; then[m
[32m+[m[32m            if [ ! -e "$BASE_DIR/.mvn/wrapper/MavenWrapperDownloader.class" ]; then[m
[32m+[m[32m                if [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m                  echo " - Compiling MavenWrapperDownloader.java ..."[m
[32m+[m[32m                fi[m
[32m+[m[32m                # Compiling the Java class[m
[32m+[m[32m                ("$JAVA_HOME/bin/javac" "$javaClass")[m
[32m+[m[32m            fi[m
[32m+[m[32m            if [ -e "$BASE_DIR/.mvn/wrapper/MavenWrapperDownloader.class" ]; then[m
[32m+[m[32m                # Running the downloader[m
[32m+[m[32m                if [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m                  echo " - Running MavenWrapperDownloader.java ..."[m
[32m+[m[32m                fi[m
[32m+[m[32m                ("$JAVA_HOME/bin/java" -cp .mvn/wrapper MavenWrapperDownloader "$MAVEN_PROJECTBASEDIR")[m
[32m+[m[32m            fi[m
[32m+[m[32m        fi[m
[32m+[m[32m    fi[m
[32m+[m[32mfi[m
[32m+[m[32m##########################################################################################[m
[32m+[m[32m# End of extension[m
[32m+[m[32m##########################################################################################[m
[32m+[m
[32m+[m[32mexport MAVEN_PROJECTBASEDIR=${MAVEN_BASEDIR:-"$BASE_DIR"}[m
[32m+[m[32mif [ "$MVNW_VERBOSE" = true ]; then[m
[32m+[m[32m  echo $MAVEN_PROJECTBASEDIR[m
[32m+[m[32mfi[m
[32m+[m[32mMAVEN_OPTS="$(concat_lines "$MAVEN_PROJECTBASEDIR/.mvn/jvm.config") $MAVEN_OPTS"[m
[32m+[m
[32m+[m[32m# For Cygwin, switch paths to Windows format before running java[m
[32m+[m[32mif $cygwin; then[m
[32m+[m[32m  [ -n "$M2_HOME" ] &&[m
[32m+[m[32m    M2_HOME=`cygpath --path --windows "$M2_HOME"`[m
[32m+[m[32m  [ -n "$JAVA_HOME" ] &&[m
[32m+[m[32m    JAVA_HOME=`cygpath --path --windows "$JAVA_HOME"`[m
[32m+[m[32m  [ -n "$CLASSPATH" ] &&[m
[32m+[m[32m    CLASSPATH=`cygpath --path --windows "$CLASSPATH"`[m
[32m+[m[32m  [ -n "$MAVEN_PROJECTBASEDIR" ] &&[m
[32m+[m[32m    MAVEN_PROJECTBASEDIR=`cygpath --path --windows "$MAVEN_PROJECTBASEDIR"`[m
[32m+[m[32mfi[m
[32m+[m
[32m+[m[32m# Provide a "standardized" way to retrieve the CLI args that will[m
[32m+[m[32m# work with both Windows and non-Windows executions.[m
[32m+[m[32mMAVEN_CMD_LINE_ARGS="$MAVEN_CONFIG $@"[m
[32m+[m[32mexport MAVEN_CMD_LINE_ARGS[m
[32m+[m
[32m+[m[32mWRAPPER_LAUNCHER=org.apache.maven.wrapper.MavenWrapperMain[m
[32m+[m
[32m+[m[32mexec "$JAVACMD" \[m
[32m+[m[32m  $MAVEN_OPTS \[m
[32m+[m[32m  -classpath "$MAVEN_PROJECTBASEDIR/.mvn/wrapper/maven-wrapper.jar" \[m
[32m+[m[32m  "-Dmaven.home=${M2_HOME}" "-Dmaven.multiModuleProjectDirectory=${MAVEN_PROJECTBASEDIR}" \[m
[32m+[m[32m  ${WRAPPER_LAUNCHER} $MAVEN_CONFIG "$@"[m
[1mdiff --git a/ACSocioambiental/mvnw.cmd b/ACSocioambiental/mvnw.cmd[m
[1mnew file mode 100644[m
[1mindex 0000000..c8d4337[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/mvnw.cmd[m
[36m@@ -0,0 +1,182 @@[m
[32m+[m[32m@REM ----------------------------------------------------------------------------[m
[32m+[m[32m@REM Licensed to the Apache Software Foundation (ASF) under one[m
[32m+[m[32m@REM or more contributor license agreements.  See the NOTICE file[m
[32m+[m[32m@REM distributed with this work for additional information[m
[32m+[m[32m@REM regarding copyright ownership.  The ASF licenses this file[m
[32m+[m[32m@REM to you under the Apache License, Version 2.0 (the[m
[32m+[m[32m@REM "License"); you may not use this file except in compliance[m
[32m+[m[32m@REM with the License.  You may obtain a copy of the License at[m
[32m+[m[32m@REM[m
[32m+[m[32m@REM    https://www.apache.org/licenses/LICENSE-2.0[m
[32m+[m[32m@REM[m
[32m+[m[32m@REM Unless required by applicable law or agreed to in writing,[m
[32m+[m[32m@REM software distributed under the License is distributed on an[m
[32m+[m[32m@REM "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY[m
[32m+[m[32m@REM KIND, either express or implied.  See the License for the[m
[32m+[m[32m@REM specific language governing permissions and limitations[m
[32m+[m[32m@REM under the License.[m
[32m+[m[32m@REM ----------------------------------------------------------------------------[m
[32m+[m
[32m+[m[32m@REM ----------------------------------------------------------------------------[m
[32m+[m[32m@REM Maven Start Up Batch script[m
[32m+[m[32m@REM[m
[32m+[m[32m@REM Required ENV vars:[m
[32m+[m[32m@REM JAVA_HOME - location of a JDK home dir[m
[32m+[m[32m@REM[m
[32m+[m[32m@REM Optional ENV vars[m
[32m+[m[32m@REM M2_HOME - location of maven2's installed home dir[m
[32m+[m[32m@REM MAVEN_BATCH_ECHO - set to 'on' to enable the echoing of the batch commands[m
[32m+[m[32m@REM MAVEN_BATCH_PAUSE - set to 'on' to wait for a keystroke before ending[m
[32m+[m[32m@REM MAVEN_OPTS - parameters passed to the Java VM when running Maven[m
[32m+[m[32m@REM     e.g. to debug Maven itself, use[m
[32m+[m[32m@REM set MAVEN_OPTS=-Xdebug -Xrunjdwp:transport=dt_socket,server=y,suspend=y,address=8000[m
[32m+[m[32m@REM MAVEN_SKIP_RC - flag to disable loading of mavenrc files[m
[32m+[m[32m@REM ----------------------------------------------------------------------------[m
[32m+[m
[32m+[m[32m@REM Begin all REM lines with '@' in case MAVEN_BATCH_ECHO is 'on'[m
[32m+[m[32m@echo off[m
[32m+[m[32m@REM set title of command window[m
[32m+[m[32mtitle %0[m
[32m+[m[32m@REM enable echoing by setting MAVEN_BATCH_ECHO to 'on'[m
[32m+[m[32m@if "%MAVEN_BATCH_ECHO%" == "on"  echo %MAVEN_BATCH_ECHO%[m
[32m+[m
[32m+[m[32m@REM set %HOME% to equivalent of $HOME[m
[32m+[m[32mif "%HOME%" == "" (set "HOME=%HOMEDRIVE%%HOMEPATH%")[m
[32m+[m
[32m+[m[32m@REM Execute a user defined script before this one[m
[32m+[m[32mif not "%MAVEN_SKIP_RC%" == "" goto skipRcPre[m
[32m+[m[32m@REM check for pre script, once with legacy .bat ending and once with .cmd ending[m
[32m+[m[32mif exist "%HOME%\mavenrc_pre.bat" call "%HOME%\mavenrc_pre.bat"[m
[32m+[m[32mif exist "%HOME%\mavenrc_pre.cmd" call "%HOME%\mavenrc_pre.cmd"[m
[32m+[m[32m:skipRcPre[m
[32m+[m
[32m+[m[32m@setlocal[m
[32m+[m
[32m+[m[32mset ERROR_CODE=0[m
[32m+[m
[32m+[m[32m@REM To isolate internal variables from possible post scripts, we use another setlocal[m
[32m+[m[32m@setlocal[m
[32m+[m
[32m+[m[32m@REM ==== START VALIDATION ====[m
[32m+[m[32mif not "%JAVA_HOME%" == "" goto OkJHome[m
[32m+[m
[32m+[m[32mecho.[m
[32m+[m[32mecho Error: JAVA_HOME not found in your environment. >&2[m
[32m+[m[32mecho Please set the JAVA_HOME variable in your environment to match the >&2[m
[32m+[m[32mecho location of your Java installation. >&2[m
[32m+[m[32mecho.[m
[32m+[m[32mgoto error[m
[32m+[m
[32m+[m[32m:OkJHome[m
[32m+[m[32mif exist "%JAVA_HOME%\bin\java.exe" goto init[m
[32m+[m
[32m+[m[32mecho.[m
[32m+[m[32mecho Error: JAVA_HOME is set to an invalid directory. >&2[m
[32m+[m[32mecho JAVA_HOME = "%JAVA_HOME%" >&2[m
[32m+[m[32mecho Please set the JAVA_HOME variable in your environment to match the >&2[m
[32m+[m[32mecho location of your Java installation. >&2[m
[32m+[m[32mecho.[m
[32m+[m[32mgoto error[m
[32m+[m
[32m+[m[32m@REM ==== END VALIDATION ====[m
[32m+[m
[32m+[m[32m:init[m
[32m+[m
[32m+[m[32m@REM Find the project base dir, i.e. the directory that contains the folder ".mvn".[m
[32m+[m[32m@REM Fallback to current working directory if not found.[m
[32m+[m
[32m+[m[32mset MAVEN_PROJECTBASEDIR=%MAVEN_BASEDIR%[m
[32m+[m[32mIF NOT "%MAVEN_PROJECTBASEDIR%"=="" goto endDetectBaseDir[m
[32m+[m
[32m+[m[32mset EXEC_DIR=%CD%[m
[32m+[m[32mset WDIR=%EXEC_DIR%[m
[32m+[m[32m:findBaseDir[m
[32m+[m[32mIF EXIST "%WDIR%"\.mvn goto baseDirFound[m
[32m+[m[32mcd ..[m
[32m+[m[32mIF "%WDIR%"=="%CD%" goto baseDirNotFound[m
[32m+[m[32mset WDIR=%CD%[m
[32m+[m[32mgoto findBaseDir[m
[32m+[m
[32m+[m[32m:baseDirFound[m
[32m+[m[32mset MAVEN_PROJECTBASEDIR=%WDIR%[m
[32m+[m[32mcd "%EXEC_DIR%"[m
[32m+[m[32mgoto endDetectBaseDir[m
[32m+[m
[32m+[m[32m:baseDirNotFound[m
[32m+[m[32mset MAVEN_PROJECTBASEDIR=%EXEC_DIR%[m
[32m+[m[32mcd "%EXEC_DIR%"[m
[32m+[m
[32m+[m[32m:endDetectBaseDir[m
[32m+[m
[32m+[m[32mIF NOT EXIST "%MAVEN_PROJECTBASEDIR%\.mvn\jvm.config" goto endReadAdditionalConfig[m
[32m+[m
[32m+[m[32m@setlocal EnableExtensions EnableDelayedExpansion[m
[32m+[m[32mfor /F "usebackq delims=" %%a in ("%MAVEN_PROJECTBASEDIR%\.mvn\jvm.config") do set JVM_CONFIG_MAVEN_PROPS=!JVM_CONFIG_MAVEN_PROPS! %%a[m
[32m+[m[32m@endlocal & set JVM_CONFIG_MAVEN_PROPS=%JVM_CONFIG_MAVEN_PROPS%[m
[32m+[m
[32m+[m[32m:endReadAdditionalConfig[m
[32m+[m
[32m+[m[32mSET MAVEN_JAVA_EXE="%JAVA_HOME%\bin\java.exe"[m
[32m+[m[32mset WRAPPER_JAR="%MAVEN_PROJECTBASEDIR%\.mvn\wrapper\maven-wrapper.jar"[m
[32m+[m[32mset WRAPPER_LAUNCHER=org.apache.maven.wrapper.MavenWrapperMain[m
[32m+[m
[32m+[m[32mset DOWNLOAD_URL="https://repo.maven.apache.org/maven2/io/takari/maven-wrapper/0.5.6/maven-wrapper-0.5.6.jar"[m
[32m+[m
[32m+[m[32mFOR /F "tokens=1,2 delims==" %%A IN ("%MAVEN_PROJECTBASEDIR%\.mvn\wrapper\maven-wrapper.properties") DO ([m
[32m+[m[32m    IF "%%A"=="wrapperUrl" SET DOWNLOAD_URL=%%B[m
[32m+[m[32m)[m
[32m+[m
[32m+[m[32m@REM Extension to allow automatically downloading the maven-wrapper.jar from Maven-central[m
[32m+[m[32m@REM This allows using the maven wrapper in projects that prohibit checking in binary data.[m
[32m+[m[32mif exist %WRAPPER_JAR% ([m
[32m+[m[32m    if "%MVNW_VERBOSE%" == "true" ([m
[32m+[m[32m        echo Found %WRAPPER_JAR%[m
[32m+[m[32m    )[m
[32m+[m[32m) else ([m
[32m+[m[32m    if not "%MVNW_REPOURL%" == "" ([m
[32m+[m[32m        SET DOWNLOAD_URL="%MVNW_REPOURL%/io/takari/maven-wrapper/0.5.6/maven-wrapper-0.5.6.jar"[m
[32m+[m[32m    )[m
[32m+[m[32m    if "%MVNW_VERBOSE%" == "true" ([m
[32m+[m[32m        echo Couldn't find %WRAPPER_JAR%, downloading it ...[m
[32m+[m[32m        echo Downloading from: %DOWNLOAD_URL%[m
[32m+[m[32m    )[m
[32m+[m
[32m+[m[32m    powershell -Command "&{"^[m
[32m+[m		[32m"$webclient = new-object System.Net.WebClient;"^[m
[32m+[m		[32m"if (-not ([string]::IsNullOrEmpty('%MVNW_USERNAME%') -and [string]::IsNullOrEmpty('%MVNW_PASSWORD%'))) {"^[m
[32m+[m		[32m"$webclient.Credentials = new-object System.Net.NetworkCredential('%MVNW_USERNAME%', '%MVNW_PASSWORD%');"^[m
[32m+[m		[32m"}"^[m
[32m+[m		[32m"[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; $webclient.DownloadFile('%DOWNLOAD_URL%', '%WRAPPER_JAR%')"^[m
[32m+[m		[32m"}"[m
[32m+[m[32m    if "%MVNW_VERBOSE%" == "true" ([m
[32m+[m[32m        echo Finished downloading %WRAPPER_JAR%[m
[32m+[m[32m    )[m
[32m+[m[32m)[m
[32m+[m[32m@REM End of extension[m
[32m+[m
[32m+[m[32m@REM Provide a "standardized" way to retrieve the CLI args that will[m
[32m+[m[32m@REM work with both Windows and non-Windows executions.[m
[32m+[m[32mset MAVEN_CMD_LINE_ARGS=%*[m
[32m+[m
[32m+[m[32m%MAVEN_JAVA_EXE% %JVM_CONFIG_MAVEN_PROPS% %MAVEN_OPTS% %MAVEN_DEBUG_OPTS% -classpath %WRAPPER_JAR% "-Dmaven.multiModuleProjectDirectory=%MAVEN_PROJECTBASEDIR%" %WRAPPER_LAUNCHER% %MAVEN_CONFIG% %*[m
[32m+[m[32mif ERRORLEVEL 1 goto error[m
[32m+[m[32mgoto end[m
[32m+[m
[32m+[m[32m:error[m
[32m+[m[32mset ERROR_CODE=1[m
[32m+[m
[32m+[m[32m:end[m
[32m+[m[32m@endlocal & set ERROR_CODE=%ERROR_CODE%[m
[32m+[m
[32m+[m[32mif not "%MAVEN_SKIP_RC%" == "" goto skipRcPost[m
[32m+[m[32m@REM check for post script, once with legacy .bat ending and once with .cmd ending[m
[32m+[m[32mif exist "%HOME%\mavenrc_post.bat" call "%HOME%\mavenrc_post.bat"[m
[32m+[m[32mif exist "%HOME%\mavenrc_post.cmd" call "%HOME%\mavenrc_post.cmd"[m
[32m+[m[32m:skipRcPost[m
[32m+[m
[32m+[m[32m@REM pause the script if MAVEN_BATCH_PAUSE is set to 'on'[m
[32m+[m[32mif "%MAVEN_BATCH_PAUSE%" == "on" pause[m
[32m+[m
[32m+[m[32mif "%MAVEN_TERMINATE_CMD%" == "on" exit %ERROR_CODE%[m
[32m+[m
[32m+[m[32mexit /B %ERROR_CODE%[m
[1mdiff --git a/ACSocioambiental/pom.xml b/ACSocioambiental/pom.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..7853328[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/pom.xml[m
[36m@@ -0,0 +1,96 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project xmlns="http://maven.apache.org/POM/4.0.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"[m
[32m+[m	[32mxsi:schemaLocation="http://maven.apache.org/POM/4.0.0 https://maven.apache.org/xsd/maven-4.0.0.xsd">[m
[32m+[m	[32m<modelVersion>4.0.0</modelVersion>[m
[32m+[m	[32m<parent>[m
[32m+[m		[32m<groupId>org.springframework.boot</groupId>[m
[32m+[m		[32m<artifactId>spring-boot-starter-parent</artifactId>[m
[32m+[m		[32m<version>2.3.10.BUILD-SNAPSHOT</version>[m
[32m+[m		[32m<relativePath/> <!-- lookup parent from repository -->[m
[32m+[m	[32m</parent>[m
[32m+[m	[32m<groupId>com.example</groupId>[m
[32m+[m	[32m<artifactId>ACSocioambiental</artifactId>[m
[32m+[m	[32m<version>0.0.1-SNAPSHOT</version>[m
[32m+[m	[32m<name>ACSocioambiental</name>[m
[32m+[m	[32m<description>Projeto S.O.S Humanidade</description>[m
[32m+[m	[32m<properties>[m
[32m+[m		[32m<java.version>1.8</java.version>[m
[32m+[m	[32m</properties>[m
[32m+[m	[32m<dependencies>[m
[32m+[m		[32m<dependency>[m
[32m+[m			[32m<groupId>org.springframework.boot</groupId>[m
[32m+[m			[32m<artifactId>spring-boot-starter-data-jpa</artifactId>[m
[32m+[m		[32m</dependency>[m
[32m+[m		[32m<dependency>[m
[32m+[m			[32m<groupId>org.springframework.boot</groupId>[m
[32m+[m			[32m<artifactId>spring-boot-starter-validation</artifactId>[m
[32m+[m		[32m</dependency>[m
[32m+[m		[32m<dependency>[m
[32m+[m			[32m<groupId>org.springframework.boot</groupId>[m
[32m+[m			[32m<artifactId>spring-boot-starter-web</artifactId>[m
[32m+[m		[32m</dependency>[m
[32m+[m
[32m+[m		[32m<dependency>[m
[32m+[m			[32m<groupId>org.springframework.boot</groupId>[m
[32m+[m			[32m<artifactId>spring-boot-devtools</artifactId>[m
[32m+[m			[32m<scope>runtime</scope>[m
[32m+[m			[32m<optional>true</optional>[m
[32m+[m		[32m</dependency>[m
[32m+[m		[32m<dependency>[m
[32m+[m			[32m<groupId>mysql</groupId>[m
[32m+[m			[32m<artifactId>mysql-connector-java</artifactId>[m
[32m+[m			[32m<scope>runtime</scope>[m
[32m+[m		[32m</dependency>[m
[32m+[m		[32m<dependency>[m
[32m+[m			[32m<groupId>org.springframework.boot</groupId>[m
[32m+[m			[32m<artifactId>spring-boot-starter-test</artifactId>[m
[32m+[m			[32m<scope>test</scope>[m
[32m+[m			[32m<exclusions>[m
[32m+[m				[32m<exclusion>[m
[32m+[m					[32m<groupId>org.junit.vintage</groupId>[m
[32m+[m					[32m<artifactId>junit-vintage-engine</artifactId>[m
[32m+[m				[32m</exclusion>[m
[32m+[m			[32m</exclusions>[m
[32m+[m		[32m</dependency>[m
[32m+[m	[32m</dependencies>[m
[32m+[m
[32m+[m	[32m<build>[m
[32m+[m		[32m<plugins>[m
[32m+[m			[32m<plugin>[m
[32m+[m				[32m<groupId>org.springframework.boot</groupId>[m
[32m+[m				[32m<artifactId>spring-boot-maven-plugin</artifactId>[m
[32m+[m			[32m</plugin>[m
[32m+[m		[32m</plugins>[m
[32m+[m	[32m</build>[m
[32m+[m	[32m<repositories>[m
[32m+[m		[32m<repository>[m
[32m+[m			[32m<id>spring-milestones</id>[m
[32m+[m			[32m<name>Spring Milestones</name>[m
[32m+[m			[32m<url>https://repo.spring.io/milestone</url>[m
[32m+[m		[32m</repository>[m
[32m+[m		[32m<repository>[m
[32m+[m			[32m<id>spring-snapshots</id>[m
[32m+[m			[32m<name>Spring Snapshots</name>[m
[32m+[m			[32m<url>https://repo.spring.io/snapshot</url>[m
[32m+[m			[32m<snapshots>[m
[32m+[m				[32m<enabled>true</enabled>[m
[32m+[m			[32m</snapshots>[m
[32m+[m		[32m</repository>[m
[32m+[m	[32m</repositories>[m
[32m+[m	[32m<pluginRepositories>[m
[32m+[m		[32m<pluginRepository>[m
[32m+[m			[32m<id>spring-milestones</id>[m
[32m+[m			[32m<name>Spring Milestones</name>[m
[32m+[m			[32m<url>https://repo.spring.io/milestone</url>[m
[32m+[m		[32m</pluginRepository>[m
[32m+[m		[32m<pluginRepository>[m
[32m+[m			[32m<id>spring-snapshots</id>[m
[32m+[m			[32m<name>Spring Snapshots</name>[m
[32m+[m			[32m<url>https://repo.spring.io/snapshot</url>[m
[32m+[m			[32m<snapshots>[m
[32m+[m				[32m<enabled>true</enabled>[m
[32m+[m			[32m</snapshots>[m
[32m+[m		[32m</pluginRepository>[m
[32m+[m	[32m</pluginRepositories>[m
[32m+[m
[32m+[m[32m</project>[m
[1mdiff --git a/ACSocioambiental/src/main/java/com/example/ACSocioambiental/AcSocioambientalApplication.java b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/AcSocioambientalApplication.java[m
[1mnew file mode 100644[m
[1mindex 0000000..edd227f[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/java/com/example/ACSocioambiental/AcSocioambientalApplication.java[m
[36m@@ -0,0 +1,13 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental;[m
[32m+[m
[32m+[m[32mimport org.springframework.boot.SpringApplication;[m
[32m+[m[32mimport org.springframework.boot.autoconfigure.SpringBootApplication;[m
[32m+[m
[32m+[m[32m@SpringBootApplication[m
[32m+[m[32mpublic class AcSocioambientalApplication {[m
[32m+[m
[32m+[m	[32mpublic static void main(String[] args) {[m
[32m+[m		[32mSpringApplication.run(AcSocioambientalApplication.class, args);[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m
[1mdiff --git a/ACSocioambiental/src/main/resources/application.properties b/ACSocioambiental/src/main/resources/application.properties[m
[1mnew file mode 100644[m
[1mindex 0000000..8b13789[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/main/resources/application.properties[m
[36m@@ -0,0 +1 @@[m
[32m+[m
[1mdiff --git a/ACSocioambiental/src/test/java/com/example/ACSocioambiental/AcSocioambientalApplicationTests.java b/ACSocioambiental/src/test/java/com/example/ACSocioambiental/AcSocioambientalApplicationTests.java[m
[1mnew file mode 100644[m
[1mindex 0000000..5828416[m
[1m--- /dev/null[m
[1m+++ b/ACSocioambiental/src/test/java/com/example/ACSocioambiental/AcSocioambientalApplicationTests.java[m
[36m@@ -0,0 +1,13 @@[m
[32m+[m[32mpackage com.example.ACSocioambiental;[m
[32m+[m
[32m+[m[32mimport org.junit.jupiter.api.Test;[m
[32m+[m[32mimport org.springframework.boot.test.context.SpringBootTest;[m
[32m+[m
[32m+[m[32m@SpringBootTest[m
[32m+[m[32mclass AcSocioambientalApplicationTests {[m
[32m+[m
[32m+[m	[32m@Test[m
[32m+[m	[32mvoid contextLoads() {[m
[32m+[m	[32m}[m
[32m+[m
[32m+[m[32m}[m

[33mcommit 2778c7db8fc7cb3e4dabbfc58f5abbfc5dea85a8[m
Author: Daniel M Oliveira <69875036+Danieloliver11@users.noreply.github.com>
Date:   Mon Mar 15 19:12:26 2021 -0300

    Update README.md

[1mdiff --git a/README.md b/README.md[m
[1mindex 1c48f45..5d599f8 100644[m
[1m--- a/README.md[m
[1m+++ b/README.md[m
[36m@@ -1 +1 @@[m
[31m-# S.O.S-HUMANIDADE-[m
\ No newline at end of file[m
[32m+[m[32m# S.O.S-HUMANIDADE[m

[33mcommit a2a16dc4f164f3ffcb77d0b596d72299ecb07f8d[m
Author: Daniel <69875036+Danieloliver11@users.noreply.github.com>
Date:   Mon Mar 15 13:23:38 2021 -0300

    texto

[1mdiff --git a/DER/Documento Projeto.rtf b/DER/Documento Projeto.rtf[m
[1mnew file mode 100644[m
[1mindex 0000000..c4fe1da[m
[1m--- /dev/null[m
[1m+++ b/DER/Documento Projeto.rtf[m	
[36m@@ -0,0 +1,10 @@[m
[32m+[m[32mGRUPO: Kevin, Daniel, Gustavo, Panda, Julia, Victor, Lucas[m[41m[m
[32m+[m[41m[m
[32m+[m[32mFizemos a primeira tabela: Categoria.[m[41m[m
[32m+[m[32mNela colocamos o 'id' como chave primária; 'nome_categoria' (varchar) para determinar os nomes das categorias; 'imagem_categoria' para inserir as fotos que vão ilustrar cada categoria; 'descricao_categoria' para descrever cada categoria.[m[41m[m
[32m+[m[41m[m
[32m+[m[32mSegunda tabela: Produto.[m[41m[m
[32m+[m[32m'id_produto' como chave primaria; 'nome' para determinar o nome de cada produto; 'preco' para determinar o preço de cada produto; 'descricao' para descrever cada produto; 'imagens' para ilustrar cada produto; 'qt_produto' para mostrar em numeros inteiros as quantidades de cada produto; 'produto_ativo' como boolean para dizer se o produto continua disponivel ou não; 'fk_id' uma chave estrangeira ligada a 'id' de categoria para que possamos determinar que categoria pertence cada produto; 'fk_usuario' é uma chave estrangeira ligada a usuario para determinar os produtos que cada usuario contribuiu.[m[41m[m
[32m+[m[41m[m
[32m+[m[32mTerceira tabela: usuario.[m[41m[m
[32m+[m[32m'id_usuario' como chave primaria; 'nome' nome completo do usuario; 'email' email do usuario para completar o login que sera necessario no site; 'senha' para completar o login.[m
\ No newline at end of file[m

[33mcommit 3fa3132bf6c0ee61063aa784a9249f52b6ad6bb5[m[33m ([m[1;31morigin/Branch-Victor[m[33m)[m
Author: Daniel <69875036+Danieloliver11@users.noreply.github.com>
Date:   Mon Mar 15 12:56:24 2021 -0300

    up.sql

[1mdiff --git a/DER/S.O.S humanidade.sql b/DER/S.O.S humanidade.sql[m
[1mnew file mode 100644[m
[1mindex 0000000..833f76e[m
[1m--- /dev/null[m
[1m+++ b/DER/S.O.S humanidade.sql[m	
[36m@@ -0,0 +1,33 @@[m
[32m+[m[32mCREATE TABLE `Produto` ([m
[32m+[m	[32m`id` INT NOT NULL AUTO_INCREMENT,[m
[32m+[m	[32m`nome` varchar NOT NULL,[m
[32m+[m	[32m`preco` varchar NOT NULL,[m
[32m+[m	[32m`descricao` varchar NOT NULL,[m
[32m+[m	[32m`imagens` varchar(255) NOT NULL,[m
[32m+[m	[32m`qt_produto` INT NOT NULL,[m
[32m+[m	[32m`produto_ativo` varchar(200) NOT NULL,[m
[32m+[m	[32m`fk_id` varchar NOT NULL,[m
[32m+[m	[32m`fk_usuario` INT NOT NULL,[m
[32m+[m	[32mPRIMARY KEY (`id`)[m
[32m+[m[32m);[m
[32m+[m
[32m+[m[32mCREATE TABLE `Usuario` ([m
[32m+[m	[32m`id` INT NOT NULL AUTO_INCREMENT,[m
[32m+[m	[32m`nome` varchar(50) NOT NULL,[m
[32m+[m	[32m`email` varchar(50) NOT NULL,[m
[32m+[m	[32m`senha` INT(50) NOT NULL,[m
[32m+[m	[32mPRIMARY KEY (`id`)[m
[32m+[m[32m);[m
[32m+[m
[32m+[m[32mCREATE TABLE `Categoria` ([m
[32m+[m	[32m`id` INT NOT NULL AUTO_INCREMENT,[m
[32m+[m	[32m`nome_categoria` BOOLEAN NOT NULL DEFAULT 'not null',[m
[32m+[m	[32m`imagem_categoria` varchar(255) NOT NULL,[m
[32m+[m	[32m`descricao_categoria` varchar(255) NOT NULL,[m
[32m+[m	[32mPRIMARY KEY (`id`)[m
[32m+[m[32m);[m
[32m+[m
[32m+[m[32mALTER TABLE `Produto` ADD CONSTRAINT `Produto_fk0` FOREIGN KEY (`fk_id`) REFERENCES `Categoria`(`id`);[m
[32m+[m
[32m+[m[32mALTER TABLE `Produto` ADD CONSTRAINT `Produto_fk1` FOREIGN KEY (`fk_usuario`) REFERENCES `Usuario`(`id`);[m
[32m+[m

[33mcommit c34e5ba4f7e79f0d4739a0ae1023c2021263e39d[m
Author: Daniel <69875036+Danieloliver11@users.noreply.github.com>
Date:   Mon Mar 15 12:29:36 2021 -0300

    UP-DER

[1mdiff --git a/DER/DER-S.O.S-HUMANIDADE.pdf b/DER/DER-S.O.S-HUMANIDADE.pdf[m
[1mnew file mode 100644[m
[1mindex 0000000..504237e[m
[1m--- /dev/null[m
[1m+++ b/DER/DER-S.O.S-HUMANIDADE.pdf[m
[36m@@ -0,0 +1 @@[m
[32m+[m[32m[m
\ No newline at end of file[m

[33mcommit 74326d7fd819fdc4e00d6917beb4704f316424a5[m
Author: Daniel M Oliveira <69875036+Danieloliver11@users.noreply.github.com>
Date:   Mon Mar 15 11:54:18 2021 -0300

    Initial commit

[1mdiff --git a/LICENSE b/LICENSE[m
[1mnew file mode 100644[m
[1mindex 0000000..8d8b885[m
[1m--- /dev/null[m
[1m+++ b/LICENSE[m
[36m@@ -0,0 +1,21 @@[m
[32m+[m[32mMIT License[m
[32m+[m
[32m+[m[32mCopyright (c) 2021 Daniel M Oliveira[m
[32m+[m
[32m+[m[32mPermission is hereby granted, free of charge, to any person obtaining a copy[m
[32m+[m[32mof this software and associated documentation files (the "Software"), to deal[m
[32m+[m[32min the Software without restriction, including without limitation the rights[m
[32m+[m[32mto use, copy, modify, merge, publish, distribute, sublicense, and/or sell[m
[32m+[m[32mcopies of the Software, and to permit persons to whom the Software is[m
[32m+[m[32mfurnished to do so, subject to the following conditions:[m
[32m+[m
[32m+[m[32mThe above copyright notice and this permission notice shall be included in all[m
[32m+[m[32mcopies or substantial portions of the Software.[m
[32m+[m
[32m+[m[32mTHE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR[m
[32m+[m[32mIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,[m
[32m+[m[32mFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE[m
[32m+[m[32mAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER[m
[32m+[m[32mLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,[m
[32m+[m[32mOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE[m
[32m+[m[32mSOFTWARE.[m
[1mdiff --git a/README.md b/README.md[m
[1mnew file mode 100644[m
[1mindex 0000000..1c48f45[m
[1m--- /dev/null[m
[1m+++ b/README.md[m
[36m@@ -0,0 +1 @@[m
[32m+[m[32m# S.O.S-HUMANIDADE-[m
\ No newline at end of file[m
