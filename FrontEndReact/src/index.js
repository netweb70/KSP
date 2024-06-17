import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Route, Routes } from 'react-router-dom'

import App from './App';
import Categoria from './views/Categoria';
import HistorialPrestamo from './views/HistorialPrestamo';
import Inicio from './views/Inicio';
import NotFound from './views/NotFound';
import Libro from './views/Libro';
import Usuario from './views/Usuario';
import Prestamo from './views/Prestamo';
import Login from './views/Login';

import UserProvider from "./context/UserProvider"
import VerificarUsuario from './componentes/VerificarUsuario';


const root = ReactDOM.createRoot(document.getElementById('wrapper'));

root.render(
    <BrowserRouter>
        <UserProvider>
            <Routes>
                <Route index path='/Login' element={<Login />} />

                <Route path='/' element={<App />}>

                    <Route index element={<Inicio />} />
                    <Route path='usuario' element={<VerificarUsuario> <Usuario /> </VerificarUsuario>} />
                    <Route path='libro' element={<VerificarUsuario> <Libro /> </VerificarUsuario>} />
                    <Route path='categoria' element={<VerificarUsuario> <Categoria /> </VerificarUsuario>} />
                    <Route path='prestamo' element={<VerificarUsuario> <Prestamo /> </VerificarUsuario>} />
                    <Route path='historialprestamo' element={<VerificarUsuario> <HistorialPrestamo /> </VerificarUsuario>} />

                </Route>
                <Route path='*' element={<NotFound />} />
                
            </Routes>

        </UserProvider>
       

    </BrowserRouter>
);

