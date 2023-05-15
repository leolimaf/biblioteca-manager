import './styles.css';
import logoImage from '../../assets/logo.svg'
import React, { useState } from "react";
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom'
import { FiArrowLeft } from 'react-icons/fi'
import api from "../../services/api";

export default function NovoLivro(){

    const [titulo, setTitulo] = useState('');
    const [autor, setAutor] = useState(''); // TODO: adicioanar tratamento para quando houver composição
    const [anoPublicacao, setAnoPublicacao] = useState('');
    const [isbn13, setIsbn13] = useState('');
    const [serie, setSerie] = useState('');
    const [volume, setVolume] = useState('');
    const [quantidadeDisponivel, setQuantidadeDisponivel] = useState('');
    const [autorId, setAutorId] = useState('1'); // TODO: adicioanar tratamento para quando houver composição
    const [editoraId, setEditoraId] = useState('1'); // TODO: adicioanar tratamento para quando houver composição

    const navigate = useNavigate();

    async function adicionarLivro(e){
        e.preventDefault();

        const data = {
            titulo,
            autor,
            anoPublicacao,
            'isbn-13': isbn13,
            serie,
            volume,
            quantidadeDisponivel,
            autorId,
            editoraId
        }
        
        const accessToken = localStorage.getItem('accessToken');

        try {
            await api.post('v1/biblioteca/adicionar-livro', data, {
                headers: {
                    Authorization: `Bearer ${accessToken}`
                }
            });
            navigate("/biblioteca");
        } catch (error) {
            alert('Não foi possível adicionar o livro, tente novamente.')
        }
    }

    return(
        <div className="new-book-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="Erudio" />
                    <h1>Adicionar Livro</h1>
                    <p>Informe os dados do livro e clique em adicionar</p>
                    <Link className="back-link" to="/biblioteca">
                        <FiArrowLeft size={16} color="#251fc5" />
                        Voltar
                    </Link>
                </section>
                <form onSubmit={adicionarLivro}>
                    <input 
                        placeholder="Título"
                        value={titulo}
                        onChange={e => setTitulo(e.target.value)}
                     />
                    <input 
                        placeholder="Autor"
                        value={autor}
                        onChange={e => setAutor(e.target.value)}
                    />
                    <input 
                        type="number"
                        placeholder="Ano de Publicação"
                        value={anoPublicacao}
                        onChange={e => setAnoPublicacao(e.target.value)}
                    />
                    <input 
                        placeholder="ISBN-13"
                        maxLength="13"
                        value={isbn13}
                        onChange={e => setIsbn13(e.target.value)}
                    />
                    <input 
                        placeholder="Série" 
                        value={serie}
                        onChange={e => setSerie(e.target.value)}
                    />
                    <input 
                        placeholder="Volume"
                        value={volume}
                        onChange={e => setVolume(e.target.value)}
                    />
                    <input 
                        placeholder="Quantidade disponível"
                        value={quantidadeDisponivel}
                        onChange={e => setQuantidadeDisponivel(e.target.value)}
                    />

                    <button className="button" type="submit">Adicionar</button>
                </form>
            </div>
        </div>
    );
}