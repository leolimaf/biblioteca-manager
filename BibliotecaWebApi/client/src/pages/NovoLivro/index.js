import './styles.css';
import logoImage from '../../assets/logo.svg'

import React from "react";
import { Link } from 'react-router-dom'
import { FiArrowLeft } from 'react-icons/fi'

export default function NovoLivro(){
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
                <form action="">
                    <input placeholder="Título" />
                    <input placeholder="Autor" />
                    <input type="date"  />
                    <input placeholder="ISBN-13" maxLength="13" />
                    <input placeholder="Série" />
                    <input placeholder="Volume" />
                    <input placeholder="Quantidade disponível" />

                    <button className="button" type="submit">Adicionar</button>
                </form>
            </div>
        </div>
    );
}