package com.example.ACSocioambiental.seguranca;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;

@EnableWebSecurity
public class BasicSecurityConfig extends WebSecurityConfigurerAdapter {
	
	/* ESSA CLASSE VEM DE 'WebSecurityConfigurerAdapter' */
	@Autowired
	private UserDetailsService userDetailsService;
	
	/* METODO PARA SOBRESCREVER O PADRAO DA CLASSE 'UserDetailsService' */
	@Override
	protected void configure(AuthenticationManagerBuilder auth) throws Exception {
		auth.userDetailsService(userDetailsService);
	}

	@Bean
	public PasswordEncoder passwordEncoder() {
		return new BCryptPasswordEncoder();
	}

	@Override
	protected void configure(HttpSecurity http) throws Exception {
		/* liberar edpoints para poderem ser acessados sem a necessidade de um token */
		http.authorizeRequests()
		.antMatchers("/usuarios/logar").permitAll()
		.antMatchers("/usuarios/cadastrar").permitAll()
		/* nao deixar acessar os demais endpoints sem estarem com um token */
		.anyRequest().authenticated()
		/* trabalha com uma seguranca basica */
		.and().httpBasic()
		.and().sessionManagement()
		/* STATELESS -> nao salva a secao */
		.sessionCreationPolicy(SessionCreationPolicy.STATELESS)
		.and().cors()
		/* desabilita as configuracoes padroes */
		.and().csrf().disable();
	}

}

