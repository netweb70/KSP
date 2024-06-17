/* eslint-disable */ 
import { useEffect, useState } from "react";
import DataTable from 'react-data-table-component';
import { Card, CardBody, CardHeader, Button, Modal, ModalHeader, ModalBody, Label, Input, FormGroup, ModalFooter, Row, Col } from "reactstrap"
import { urlCategoriaLista } from "./endpoints.js";
import { urlLibroLista } from "./endpoints.js";
import { urlLibroGuardar } from "./endpoints.js";
import { urlLibroEditar } from "./endpoints.js";
import { urlLibroEliminar } from "./endpoints.js";

import { itemNegocio1 } from "./global.js";
import { itemNegocio1Singular } from "./global.js";


import Swal from 'sweetalert2'

const modeloLibro = {
    idLibro :0,
    codigo :"",
    editorial :"",
    descripcion :"",
    idCategoria :0,
    stock :0,
    esActivo: true
}


const Libro = () => {

    const [libro, setLibro] = useState(modeloLibro);
    const [pendiente, setPendiente] = useState(true);
    const [libros, setLibros] = useState([]);
    const [categorias, setCategorias] = useState([]);
    const [verModal, setVerModal] = useState(false);

    const handleChange = (e) => {

        console.log(e.target.value)

        let value;

        if (e.target.name == "idCategoria") {
            value = e.target.value
        } else if (e.target.name == "esActivo") {
            value = (e.target.value == "true" ? true : false)
        } else {
            value = e.target.value;
        }

        setLibro({
            ...libro,
            [e.target.name]: value
        })


    }

    const obtenerCategorias = async () => {
        let response = await fetch(urlCategoriaLista);
        if (response.ok) {
            let data = await response.json()
            setCategorias(data)
        }
    }

    const obtenerLibros = async () => {
        let response = await fetch(urlLibroLista);

        if (response.ok) {
            let data = await response.json()
            setLibros(data)
            setPendiente(false)
        }
    }

    useEffect(() => {
        obtenerCategorias();
        obtenerLibros();
    }, [])


    const columns = [
        {
            name: 'Codigo',
            selector: row => row.codigo,
            sortable: true,
        },
        {
            name: 'Editorial',
            selector: row => row.editorial,
            sortable: true,
        },
        {
            name: 'Descripcion',
            selector: row => row.descripcion,
            sortable: true,
        },
        {
            name: 'Categoria',
            selector: row => row.idCategoriaNavigation,
            sortable: true,
            cell: row => (row.idCategoriaNavigation.descripcion)
        },
        {
            name: 'Estado',
            selector: row => row.esActivo,
            sortable: true,
            cell: row => {
                let clase;
                clase = row.esActivo ? "badge badge-info p-2" : "badge badge-danger p-2"
                return (
                    <span className={clase}>{row.esActivo ? "Activo" : "No Activo"}</span>
                )
            }
        },
        {
            name: '',
            cell: row => (
                <>
                    <Button color="primary" size="sm" className="mr-2"
                        onClick={() => abrirEditarModal(row)}
                    >
                        <i className="fas fa-pen-alt"></i>
                    </Button>

                    <Button color="danger" size="sm"
                        onClick={() => eliminarLibro(row.idLibro)}
                    >
                        <i className="fas fa-trash-alt"></i>
                    </Button>
                </>
            ),
        },
    ];

    const customStyles = {
        headCells: {
            style: {
                fontSize: '13px',
                fontWeight: 800,
            },
        },
        headRow: {
            style: {
                backgroundColor: "#eee",
            }
        }
    };

    const paginationComponentOptions = {
        rowsPerPageText: 'Filas por página',
        rangeSeparatorText: 'de',
        selectAllRowsItem: true,
        selectAllRowsItemText: 'Todos',
    };

    const abrirEditarModal = (data) => {
        setLibro(data);
        setVerModal(!verModal);
    }

    const cerrarModal = () => {
        setLibro(modeloLibro)
        setVerModal(!verModal);
    }

    const guardarCambios = async () => {
        delete libro.idCategoriaNavigation;

        let response;
        if (libro.idLibro == 0) {
            response = await fetch(urlLibroGuardar, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(libro)
            })

        } else {
            response = await fetch(urlLibroEditar, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json;charset=utf-8'
                },
                body: JSON.stringify(libro)
            })
        }
        if (response.ok) {
            await obtenerLibros();
            setLibro(modeloLibro)
            setVerModal(!verModal);

        } else {
            Swal.fire(
                'Opp!',
                'No se pudo guardar.',
                'warning'
            )
        }

    }

    const eliminarLibro = async (id) => {

        Swal.fire({
            title: 'Esta seguro?',
            text: "Desea eliminar el " + itemNegocio1Singular,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, continuar',
            cancelButtonText: 'No, volver'
        }).then((result) => {
            if (result.isConfirmed) {
                const response = fetch(urlLibroEliminar + "/" + id, { method: "DELETE" })
                    .then(response => {
                        if (response.ok) {

                            obtenerLibros();

                            Swal.fire(
                                'Eliminado!',
                                'El ' + itemNegocio1Singular + ' fue eliminado.',
                                'success'
                            )
                        } else {
                            Swal.fire(
                                'Error de integridad de datos',
                                'No se puede eliminar porque existen registros de ' + itemNegocio1 + ' relacionados.',
                                'info'
                            )                            
                        }

                    })
            }
        })
    }

    return (
        <>
            <Card>
                <CardHeader style={{ backgroundColor: '#4e73df', color: "white" }}>
                    Lista de {itemNegocio1}
                </CardHeader>
                <CardBody>
                    <Button color="success" size="sm" onClick={() => setVerModal(!verModal)}>Agregar {itemNegocio1Singular}</Button>
                    <hr></hr>
                    <DataTable
                        columns={columns}
                        data={libros}
                        progressPending={pendiente}
                        pagination
                        paginationComponentOptions={paginationComponentOptions}
                        customStyles={ customStyles}
                    />
                </CardBody>
            </Card>

            <Modal isOpen={verModal}>
                <ModalHeader>
                    Detalle {itemNegocio1Singular}
                </ModalHeader>
                <ModalBody>
                    <Row>
                        <Col sm={6}>
                            <FormGroup>
                                <Label>Codigo</Label>
                                <Input bsSize="sm" name="codigo" onChange={handleChange} value={libro.codigo} />
                            </FormGroup>
                        </Col>
                        <Col sm={6}>
                            <FormGroup>
                                <Label>Editorial</Label>
                                <Input bsSize="sm" name="editorial" onChange={handleChange} value={libro.editorial} />
                            </FormGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col sm={6}>
                            <FormGroup>
                                <Label>Descripcion</Label>
                                <Input bsSize="sm" name="descripcion" onChange={handleChange} value={libro.descripcion} />
                            </FormGroup>
                        </Col>
                        <Col sm={6}>
                            <FormGroup>
                                <Label>Categoria</Label>
                                <Input bsSize="sm" type={"select"} name="idCategoria" onChange={handleChange} value={libro.idCategoria} >
                                    <option value={0}>Seleccionar</option>
                                    {
                                        categorias.map((item) => {
                                            if (item.esActivo)
                                                return (<option key={item.idCategoria} value={item.idCategoria}>{item.descripcion}</option>)
                                        } )
                                    }
                                </Input>
                            </FormGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col sm={6}>
                            <FormGroup>
                                <Label>Stock</Label>
                                <Input bsSize="sm" name="stock" onChange={handleChange} value={libro.stock} type="number" />
                            </FormGroup>
                        </Col>
                        <Col sm={6}>
                            <FormGroup>
                            <Label>Estado</Label>
                                <Input bsSize="sm" type={"select"} name="esActivo" onChange={handleChange} value={libro.esActivo} >
                                    <option value={true}>Activo</option>
                                    <option value={false}>No Activo</option>
                                </Input>
                            </FormGroup>
                        </Col>
                    </Row>


                </ModalBody>
                <ModalFooter>
                    <Button size="sm" color="primary" onClick={guardarCambios}>Guardar</Button>
                    <Button size="sm" color="danger" onClick={cerrarModal}>Cerrar</Button>
                </ModalFooter>
            </Modal>
        </>
    )
}

export default Libro;