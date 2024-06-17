/* eslint-disable */ 
import React, { useContext } from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { UserContext } from '../context/UserProvider';
import { itemNegocio1 } from "../views/global.js";

const modelo = {
    nombre: "",
    correo: "",
    idRolNavigation: {
        idRol:0,
        descripcion: ""
    }
}
const NavBar = () => {

    const { user} = useContext(UserContext);

    const [dataUser, setDataUser] = useState(modelo)

    useEffect(() => {
        let dt = JSON.parse(user)
        setDataUser(dt)

    }, [])
    return (
        
        <ul className="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

            <Link className="sidebar-brand d-flex align-items-center justify-content-center" to="/">
                <div className="sidebar-brand-icon">
                    <i className="fa-solid fa-book"></i>
                </div>
                <div className="sidebar-brand-text mx-3">Biblioteca</div>
            </Link>

            <hr className="sidebar-divider my-0" />


            <hr className="sidebar-divider" />
            {
                (dataUser.idRolNavigation.descripcion == "Administrador") &&
                <li className="nav-item">
                    <a className="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseUsuario"
                        aria-expanded="true" aria-controls="collapseUsuario">
                        <i className="fas fa-fw fa-cog"></i>
                        <span>Administracion</span>
                    </a>
                    <div id="collapseUsuario" className="collapse" aria-labelledby="headingTwo" data-parent="#accordionSidebar">
                        <div className="bg-white py-2 collapse-inner rounded">
                            <NavLink to="/usuario" className="collapse-item">Usuarios</NavLink>
                        </div>
                    </div>
                </li>
            }
            
            {
                (dataUser.idRolNavigation.descripcion == "Administrador") &&
                <li className="nav-item">
                    <a className="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseInventario"
                        aria-expanded="true" aria-controls="collapseInventario">
                        <i className="fas fa-fw fa-box"></i>
                        <span>Inventario</span>
                    </a>
                    <div id="collapseInventario" className="collapse" aria-labelledby="headingUtilities"
                        data-parent="#accordionSidebar">
                        <div className="bg-white py-2 collapse-inner rounded">
                            <NavLink to="/libro" className="collapse-item">{itemNegocio1}</NavLink>
                            <NavLink to="/categoria" className="collapse-item">Categorias</NavLink>
                        </div>
                    </div>
                </li>
            }
           

            <li className="nav-item">
                <a className="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapsePrestamo"
                    aria-expanded="true" aria-controls="collapsePrestamo">
                    <i className="fas fa-fw fa-tag"></i>
                    <span>Prestamo de libros</span>
                </a>
                <div id="collapsePrestamo" className="collapse" aria-labelledby="headingUtilities"
                    data-parent="#accordionSidebar">
                    <div className="bg-white py-2 collapse-inner rounded">
                        <NavLink to="/prestamo" className="collapse-item">Registrar prestamo</NavLink>
                        <NavLink to="/historialprestamo" className="collapse-item">Historial Prestamos</NavLink>
                    </div>
                </div>
            </li>

            <hr className="sidebar-divider d-none d-md-block" />

            <div className="text-center d-none d-md-inline">
                <button className="rounded-circle border-0" id="sidebarToggle"></button>
            </div>

        </ul>
        )
}

export default NavBar;