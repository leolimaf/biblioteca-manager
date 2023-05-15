import React from "react";
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'

import Login from './pages/Login';
import Livro from './pages/Biblioteca';
import NovoLivro from './pages/NovoLivro';

export default function MyRoutes(){
    return(
        <Router>
            <Routes>
                <Route path="/" element={<Login/>}/>
                <Route path="/biblioteca" element={<Livro/>}/>
                <Route path="/biblioteca/adicionar-livro/" element={<NovoLivro/>}/>
                <Route path="/biblioteca/atualizar-livro/:livroId" element={<NovoLivro/>}/>
            </Routes>
        </Router>
    );
}