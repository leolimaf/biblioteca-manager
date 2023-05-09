import './styles.css';
import logoImage from '../../assets/logo.svg'

import React from "react";
import { Link } from 'react-router-dom';
import { FiPower, FiEdit, FiTrash2 } from 'react-icons/fi'

export default function Livro(){
    return(
        <div className="book-container">
            <header>
                <img src={logoImage} alt="Erudio"/>
                <span>Bem vindo, <strong>Leonardo</strong>!</span>
                <Link className="button" to="adicionar-livro">Adicionar Livro</Link>
                <button type="button">
                    <FiPower size={18} color="#251fc5" />
                </button>
            </header>

            <h1>Livros Registrados</h1>
            <ul>
                <li>
                    <strong>Título:</strong>
                    <p>Docker Deep Dive</p>
                    <strong>Autor:</strong>
                    <p>DNigel Poulton</p>
                    <strong>Data de Lançamento:</strong>
                    <p>12/07/2017</p>
                    <strong>ISBN-13</strong>
                    <p>1234567890123</p>
                    <strong>Série</strong>
                    <p>Docker 123</p>
                    <strong>Volume</strong>
                    <p>1</p>

                    <button type="button">
                        <FiEdit size={20} color="#251fc5"/>
                    </button>
                    <button type="button">
                        <FiTrash2 size={20} color="#251fc5"/>
                    </button>
                </li>
                <li>
                    <strong>Título:</strong>
                    <p>Docker Deep Dive</p>
                    <strong>Autor:</strong>
                    <p>DNigel Poulton</p>
                    <strong>Data de Lançamento:</strong>
                    <p>12/07/2017</p>
                    <strong>ISBN-13</strong>
                    <p>1234567890123</p>
                    <strong>Série</strong>
                    <p>Docker 123</p>
                    <strong>Volume</strong>
                    <p>1</p>

                    <button type="button">
                        <FiEdit size={20} color="#251fc5"/>
                    </button>
                    <button type="button">
                        <FiTrash2 size={20} color="#251fc5"/>
                    </button>
                </li>
                <li>
                    <strong>Título:</strong>
                    <p>Docker Deep Dive</p>
                    <strong>Autor:</strong>
                    <p>DNigel Poulton</p>
                    <strong>Data de Lançamento:</strong>
                    <p>12/07/2017</p>
                    <strong>ISBN-13</strong>
                    <p>1234567890123</p>
                    <strong>Série</strong>
                    <p>Docker 123</p>
                    <strong>Volume</strong>
                    <p>1</p>

                    <button type="button">
                        <FiEdit size={20} color="#251fc5"/>
                    </button>
                    <button type="button">
                        <FiTrash2 size={20} color="#251fc5"/>
                    </button>
                </li>
                <li>
                    <strong>Título:</strong>
                    <p>Docker Deep Dive</p>
                    <strong>Autor:</strong>
                    <p>DNigel Poulton</p>
                    <strong>Data de Lançamento:</strong>
                    <p>12/07/2017</p>
                    <strong>ISBN-13</strong>
                    <p>1234567890123</p>
                    <strong>Série</strong>
                    <p>Docker 123</p>
                    <strong>Volume</strong>
                    <p>1</p>

                    <button type="button">
                        <FiEdit size={20} color="#251fc5"/>
                    </button>
                    <button type="button">
                        <FiTrash2 size={20} color="#251fc5"/>
                    </button>
                </li>
                <li>
                    <strong>Título:</strong>
                    <p>Docker Deep Dive</p>
                    <strong>Autor:</strong>
                    <p>DNigel Poulton</p>
                    <strong>Data de Lançamento:</strong>
                    <p>12/07/2017</p>
                    <strong>ISBN-13</strong>
                    <p>1234567890123</p>
                    <strong>Série</strong>
                    <p>Docker 123</p>
                    <strong>Volume</strong>
                    <p>1</p>

                    <button type="button">
                        <FiEdit size={20} color="#251fc5"/>
                    </button>
                    <button type="button">
                        <FiTrash2 size={20} color="#251fc5"/>
                    </button>
                </li>
                <li>
                    <strong>Título:</strong>
                    <p>Docker Deep Dive</p>
                    <strong>Autor:</strong>
                    <p>DNigel Poulton</p>
                    <strong>Data de Lançamento:</strong>
                    <p>12/07/2017</p>
                    <strong>ISBN-13</strong>
                    <p>1234567890123</p>
                    <strong>Série</strong>
                    <p>Docker 123</p>
                    <strong>Volume</strong>
                    <p>1</p>

                    <button type="button">
                        <FiEdit size={20} color="#251fc5"/>
                    </button>
                    <button type="button">
                        <FiTrash2 size={20} color="#251fc5"/>
                    </button>
                </li>
            </ul>
        </div>
    );
}