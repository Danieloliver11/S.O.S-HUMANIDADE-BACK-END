package com.example.ACSocioambiental.Security;

import java.util.Collection;
import java.util.List;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import com.example.ACSocioambiental.Model.Usuario;

public class UserDetailsImplementation implements UserDetails {
	
	private static final long serialVersionUID = 1L;
	
	private String userName;
	
	private String password;
	
	private List<GrantedAuthority> Authorities;
	
	/*public UserDetailsImplementation (String userName,String password) {
		this.userName = userName;
		this.password = password;
	}*/
	public UserDetailsImplementation(Usuario user) {
        this.userName = user.getUsuario();
        this.password = user.getSenha();
    }
	
	public UserDetailsImplementation() {}

	@Override
	public Collection<? extends GrantedAuthority> getAuthorities() {
		// TODO Auto-generated method stub
		return Authorities;
	}

	@Override
	public String getPassword() {
		// TODO Auto-generated method stub
		return password;
	}

	@Override
	public String getUsername() {
		// TODO Auto-generated method stub
		return userName;
	}

	@Override
	public boolean isAccountNonExpired() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isAccountNonLocked() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isCredentialsNonExpired() {
		// TODO Auto-generated method stub
		return true;
	}

	@Override
	public boolean isEnabled() {
		// TODO Auto-generated method stub
		return true;
	}
	
	

}
