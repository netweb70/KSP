/* eslint-disable */
import { Card, CardBody, CardHeader, Col, FormGroup, Input, Label, Row, Table, Button, Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import DatePicker from "react-datepicker";
import Swal from 'sweetalert2'

import "react-datepicker/dist/react-datepicker.css";
import { useState, useEffect } from "react";

import { urlPrestamoListar } from "./endpoints.js";
import { urlPrestamoRegistrarDevolucion } from "./endpoints.js";

const HistorialPrestamo = () => {
    const [fechaInicio, setFechaInicio] = useState(new Date());
    const [fechaFin, setFechaFin] = useState(new Date());
    const [nroPrestamo, setNumeroPrestamo] = useState("")
    const [buscarPor, setBuscarPor] = useState("fecha")
    const [devuelta, setDevuelta] = useState("")

    const [verModal, setVerModal] = useState(false)
    const [detallePrestamo, setDetallePrestamo] = useState({})
    const [ventas, setPrestamos] = useState([])

    const [mostrarCapDevolucion, setMostrarCapDevolucion] = useState(false);

    useEffect(() => {
        if (detallePrestamo.detalle !== undefined) {
            var mostarCaptura = detallePrestamo.detalle[0].cantidad !==
                detallePrestamo.detalle[0].devuelta ? true : false;

            setMostrarCapDevolucion(mostarCaptura);
        }
    });


    const buscarPrestamo = () => {
        let options = { year: 'numeric', month: '2-digit', day: '2-digit' };

        let _fechaInicio = fechaInicio.toLocaleDateString('es-MX', options)
        let _fechaFin = fechaFin.toLocaleDateString('es-MX', options)

        const api = fetch(`${urlPrestamoListar}?buscarPor=${buscarPor}&numeroPrestamo=${nroPrestamo}&fechaInicio=${_fechaInicio}&fechaFin=${_fechaFin}`)
            .then((response) => {
                return response.ok ? response.json() : Promise.reject(response);
            })
            .then((dataJson) => {
                var data = dataJson;
                if (data.length < 1) {
                    Swal.fire(
                        'Opps!',
                        'No se encontraron resultados',
                        'warning'
                    )
                }

                setPrestamos(data);

            }).catch((error) => {
                setPrestamos([]);
                Swal.fire(
                    'Opps!',
                    'No se pudo encontrar información',
                    'error'
                )
            })

    }

    const mostrarModal = (data) => {
        setDetallePrestamo(data)
        setVerModal(!verModal);
    }

    const registroDevolucion = () => {

        if (devuelta.length < 1) {
            Swal.fire(
                'Mensaje',
                'Indicar la cantidad a devolver',
                'warning'
            )
            return
        }
        if (devuelta > detallePrestamo.detalle[0].cantidad) {
            Swal.fire(
                'Mensaje',
                'La cantidad a devolver debe ser menor o igual a lo prestado',
                'warning'
            )
            return
        }

        let devolucion = {
            idDetallePrestamo: detallePrestamo.detalle[0].idDetallePrestamo,
            devuelta: devuelta,
        }

        const api = fetch(urlPrestamoRegistrarDevolucion, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(devolucion)
        })
            .then((response) => {
                return response.ok ? "" : Promise.reject(response);
            })
            .then(() => {
                Swal.fire(
                    'Devolucion registrada!',
                    'success'
                )

            }).catch((error) => {
                Swal.fire(
                    'Error!',
                    'No se pudo actualizar el registro',
                    'error'
                )
                console.log("No se pudo registar ", error)
            })

    }


    return (
        <>
            <Row>
                <Col sm={12}>
                    <Card>
                        <CardHeader style={{ backgroundColor: '#4e73df', color: "white" }}>
                            Historial de prestamos
                        </CardHeader>
                        <CardBody>
                            <Row className="align-items-end">
                                <Col sm={3}>
                                    <FormGroup>
                                        <Label>Buscar por: </Label>
                                        <Input type="select" bsSize="sm" onChange={(e) => setBuscarPor(e.target.value)}
                                            value={buscarPor}
                                        >
                                            <option value="fecha">Fechas</option>
                                            <option value="numero">Folio de registro</option>
                                        </Input>
                                    </FormGroup>
                                </Col>
                                {
                                    (buscarPor == "fecha") ? (
                                        <>
                                            <Col sm={3}>
                                                <FormGroup>
                                                    <Label>Fecha Inicio:</Label>
                                                    <DatePicker
                                                        className="form-control form-control-sm"
                                                        selected={fechaInicio}
                                                        onChange={(date) => setFechaInicio(date)}
                                                        dateFormat='dd/MM/yyyy'
                                                    />
                                                </FormGroup>
                                            </Col>

                                            <Col sm={3}>
                                                <FormGroup>
                                                    <Label>Fecha Fin:</Label>
                                                    <DatePicker
                                                        className="form-control form-control-sm"
                                                        selected={fechaFin}
                                                        onChange={(date) => setFechaFin(date)}
                                                        dateFormat='dd/MM/yyyy'
                                                    />
                                                </FormGroup>
                                            </Col>
                                        </>
                                    ) : (
                                        <Col sm={3}>
                                            <FormGroup>
                                                <Label>Folio generado:</Label>
                                                <Input bsSize="sm" value={nroPrestamo} onChange={(e) => setNumeroPrestamo(e.target.value)} />
                                            </FormGroup>
                                        </Col>
                                    )
                                }
                                <Col sm={3}>
                                    <FormGroup>
                                        <Button color="primary" size="sm" block onClick={buscarPrestamo}>
                                            <i className="fa fa-search" aria-hidden="true"></i> Buscar
                                        </Button>
                                    </FormGroup>
                                </Col>
                            </Row>
                            <hr></hr>
                            <Row>
                                <Col sm="12">
                                    <Table striped responsive size="sm">
                                        <thead>
                                            <tr>
                                                <th>Fecha Registro</th>
                                                <th>Folio de registro</th>
                                                <th>Tipo Documento</th>
                                                <th>Dato documento identificacion</th>
                                                <th>Nombre solicitante</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {
                                                (ventas.length < 1) ? (
                                                    <tr>
                                                        <td colSpan="7" style={{ textAlign: "center" }}>
                                                            Sin resultados
                                                        </td>
                                                    </tr>
                                                ) : (

                                                    ventas.map((item) => (
                                                        <tr key={item.numeroDocumento}>
                                                            <td>{item.fechaRegistro}</td>
                                                            <td>{item.numeroDocumento}</td>
                                                            <td>{item.tipoDocumento}</td>
                                                            <td>{item.documentoCliente}</td>
                                                            <td>{item.nombreCliente}</td>
                                                            <td>
                                                                <Button size="sm" color="primary" outline
                                                                    onClick={() => mostrarModal(item)}
                                                                >
                                                                    {

                                                                        (item.detalle[0].cantidad !== item.detalle[0].devuelta) ? (
                                                                            <>
                                                                                <i className="fa fa-exchange" aria-hidden="true"></i> Aplicar devolucion
                                                                            </>
                                                                        ) :
                                                                            (
                                                                                <>
                                                                                    <i className="fa fa-eye" aria-hidden="true"></i> Ver detalle
                                                                                </>
                                                                            )
                                                                    }

                                                                </Button>
                                                            </td>
                                                        </tr>
                                                    ))
                                                )
                                            }
                                        </tbody>
                                    </Table>

                                </Col>

                            </Row>

                        </CardBody>
                    </Card>
                </Col>
            </Row>

            <Modal size="lg" isOpen={verModal}>
                <ModalHeader>
                    Detalle prestamo
                </ModalHeader>
                <ModalBody>
                    <Row>
                        <Col sm={4}>
                            <FormGroup>
                                <Label>Fecha Registro:</Label>
                                <Input bsSize="sm" disabled value={detallePrestamo.fechaRegistro} />
                            </FormGroup>
                        </Col>
                        <Col sm={4}>
                            <FormGroup>
                                <Label>Folio de registro:</Label>
                                <Input bsSize="sm" disabled value={detallePrestamo.numeroDocumento} />
                            </FormGroup>
                        </Col>
                        <Col sm={4}>
                            <FormGroup>
                                <Label>Documento identificacion:</Label>
                                <Input bsSize="sm" disabled value={detallePrestamo.tipoDocumento} />
                            </FormGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col sm={4}>
                            <FormGroup>
                                <Label>Usuario Registro:</Label>
                                <Input bsSize="sm" disabled value={detallePrestamo.usuarioRegistro} />
                            </FormGroup>
                        </Col>
                        <Col sm={4}>
                            <FormGroup>
                                <Label>Dato documento identificacion:</Label>
                                <Input bsSize="sm" disabled value={detallePrestamo.documentoCliente} />
                            </FormGroup>
                        </Col>
                        <Col sm={4}>
                            <FormGroup>
                                <Label>Nombre solicitante:</Label>
                                <Input bsSize="sm" disabled value={detallePrestamo.nombreCliente} />
                            </FormGroup>
                        </Col>
                    </Row>
                    <br />
                    {
                        mostrarCapDevolucion &&
                        <Row>
                            <Col sm={4}>
                                <FormGroup>
                                    <Label>Cantidad a devolucion:</Label>
                                    <Input bsSize="sm" value={devuelta} onChange={(e) => setDevuelta(e.target.value)} />
                                </FormGroup>
                            </Col>
                            <Col sm={4}>
                                <FormGroup>
                                    <Label>Valide la cantidad entregada:</Label><br />
                                    <Button size="sm" color="primary" onClick={() => registroDevolucion()}>Aplicar devolucion</Button>
                                </FormGroup>
                            </Col>
                        </Row>
                    }

                    <Row>
                        <Col sm={12}>
                            <Table size="sm">
                                <thead>
                                    <tr>
                                        <th>Libro</th>
                                        <th>Cantidad</th>
                                        <th>Cantidad devuelta</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        (detallePrestamo.detalle == undefined) ? (
                                            <tr><td colSpan={4}>Sin libros</td></tr>
                                        ) : (
                                            detallePrestamo.detalle.map((item) => (
                                                <tr key={item.libro}>
                                                    <td>{item.libro}</td>
                                                    <td>{item.cantidad}</td>
                                                    <td>{item.devuelta}</td>
                                                </tr>
                                            ))
                                        )
                                    }

                                </tbody>
                            </Table>
                        </Col>
                    </Row>


                </ModalBody>
                <ModalFooter>
                    <Button size="sm" color="danger" onClick={() => setVerModal(!verModal)}>Cerrar</Button>
                </ModalFooter>
            </Modal>
        </>



    )
}

export default HistorialPrestamo;