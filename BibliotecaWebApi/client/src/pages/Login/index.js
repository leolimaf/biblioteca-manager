import React, { useState } from "react";
import { useNavigate } from 'react-router-dom';
import './styles.css';
import logoImage from '../../assets/logo.svg'
import padlock from '../../assets/padlock.png'
import api from "../../services/api";

export default function Login(){

    const [matricula, setMatricula] = useState('');
    const [senha, setSenha] = useState('');

    const navigate = useNavigate();

    async function login(e){
        e.preventDefault();

        const data = {
            matricula,
            senha,
        };

        try {
            const response = await api.post('v1/autenticacao/logar', data)
            localStorage.setItem('matricula', matricula);
            localStorage.setItem('accessToken', response.data.accessToken);
            localStorage.setItem('refreshToken', response.data.refreshToken);

            navigate("/biblioteca");
        } catch (error) {
            alert('Falha no login, tente novamente.');
        }
    }

    return(
        <div className="login-container">
            <section className="form">
                <img src={logoImage} alt="Erudio Logo"/>
                <form onSubmit={login}>
                    <h1>Acesse a sua conta</h1>
                    <input 
                        placeholder="Usuário"
                        value={matricula}
                        onChange={e => setMatricula(e.target.value)}
                    />
                    <input 
                        type="password"
                        placeholder="Senha"
                        value={senha}
                        onChange={e => setSenha(e.target.value)}
                    />

                    <button className="button" type="submit">Login</button>
                </form>
            </section>

            <img src={padlock} alt="Login"/>
        </div>
    )
}