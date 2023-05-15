import './styles.css';
import logoImage from '../../assets/logo.svg'
import React, { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { FiPower, FiEdit, FiTrash2 } from 'react-icons/fi'
import api from "../../services/api";

export default function Livro(){

    const [livros, setLivros] = useState([]);

    const matricula = localStorage.getItem('matricula');
    const accessToken = localStorage.getItem('accessToken');

    const navigate = useNavigate();

    useEffect(() => {
        api.get('v1/biblioteca/listar-livros', {
            headers: {
                Authorization: `Bearer ${accessToken}`
            }
        }).then(response => {
            setLivros(response.data)
        })
    }, [accessToken])

    async function deletarLivro(id){
        try {
            await api.delete(`v1/biblioteca/remover-livro-por-id?id=${id}`, {
                headers: {
                    Authorization: `Bearer ${accessToken}`
                }
            });
            setLivros(livros.filter(livro => livro.id !== id));
        } catch (error) {
            alert('Falha ao excluir livro, tente novamente.')
        }
    }

    return(
        <div className="book-container">
            <header>
                <img src={logoImage} alt="Erudio"/>
                <span>Bem vindo, <strong>{matricula.toLowerCase()}</strong>!</span>
                <Link className="button" to="adicionar-livro">Adicionar Livro</Link>
                <button type="button">
                    <FiPower size={18} color="#251fc5" />
                </button>
            </header>

            <h1>Livros Registrados</h1>
            <ul>
                {livros.map(livro => (
                    <li key={livro.id}>
                        <strong>Título:</strong>
                        <p>{livro.titulo}</p>
                        <strong>Autor:</strong>
                        <p>{livro.autor.nomeCompleto}</p>
                        <strong>Ano de Lançamento:</strong>
                        <p>{livro.anoPublicacao}</p>
                        <strong>ISBN-13</strong>
                        <p>{livro['isbn-13']}</p>
                        <strong>Série</strong>
                        <p>{livro.serie}</p>
                        <strong>Volume</strong>
                        <p>{livro.volume}</p>

                        <button type="button">
                            <FiEdit size={20} color="#251fc5"/>
                        </button>
                        <button type="button" onClick={() => deletarLivro(livro.id)}>
                            <FiTrash2 size={20} color="#251fc5"/>
                        </button>
                    </li>
                ))}
            </ul>
        </div>
    );
}