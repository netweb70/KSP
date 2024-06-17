/* eslint-disable */ 
import { Card, CardBody, CardHeader, Col, FormGroup, Input, InputGroup, InputGroupText, Label, Row, Table, Button } from "reactstrap";
import Swal from 'sweetalert2'
import Autosuggest from 'react-autosuggest';
import { useContext, useState } from "react";
import "./css/Prestamo.css"
import { UserContext } from "../context/UserProvider.js";
import { urlPrestamoLibros } from "./endpoints.js";
import { urlPrestamoRegistrar } from "./endpoints.js";

const Prestamo = () => {
    const { user } = useContext(UserContext)

    const [a_Libros, setA_Libros] = useState([])
    const [a_Busqueda, setA_Busqueda] = useState("")

    const [documentoCliente, setDocumentoCliente] = useState("")
    const [nombreCliente, setNombreCliente] = useState("")

    const [tipoDocumento,setTipoDocumento] = useState("Boleta")
    const [libros, setLibros] = useState([])
    

    const reestablecer = () => {
        setDocumentoCliente("");
        setNombreCliente("")
        setTipoDocumento("Boleta")
        setLibros([])
    }

    // lista de libros sugeridos
    const onSuggestionsFetchRequested = ({ value }) => {

        const api = fetch(urlPrestamoLibros + "/" + value)
            .then((response) => {
                return response.ok ? response.json() : Promise.reject(response);
            })
            .then((dataJson) => {
                setA_Libros(dataJson)
            }).catch((error) => {
                console.log("No se pudo obtener datos, mayor detalle: ", error)
            })
        
    }

    
    const onSuggestionsClearRequested = () => {
        setA_Libros([])
    }

    const getSuggestionValue = (sugerencia) => {
        return sugerencia.codigo + " - " + sugerencia.editorial + " - " + sugerencia.descripcion
    }

    const renderSuggestion = (sugerencia) => (
        <span>
            {sugerencia.codigo + " - " + sugerencia.editorial + " - " + sugerencia.descripcion}
        </span>
     )

    const onChange = (e, {newValue}) => {
        setA_Busqueda(newValue)
    }

    const inputProps = {
        placeholder : "Buscar libro",
        value: a_Busqueda,
        onChange
    }

    const sugerenciaSeleccionada = (event, { suggestion, suggestionValue, suggestionIndex, sectionIndex, method }) => {

        Swal.fire({
            title: "Editorial: " + suggestion.editorial +", Titulo:" + suggestion.descripcion,
            text:"Ingrese la cantidad",
            input: 'text',
            inputAttributes: {
                autocapitalize: 'off'
            },
            showCancelButton: true,
            confirmButtonText: 'Aceptar',
            cancelButtonText: 'Volver',
            showLoaderOnConfirm: true,
            preConfirm: (inputValue) => {

                
                if (isNaN(parseFloat(inputValue))) {
                    setA_Busqueda("")
                    Swal.showValidationMessage(
                        "Debe ingresar un valor númerico"
                    )
                } else {

                    let libro = {
                        idLibro: suggestion.idLibro,
                        descripcion: suggestion.descripcion,
                        cantidad: parseInt(inputValue),
                    }
                    let arrayProductos = []
                    arrayProductos.push(...libros)
                    arrayProductos.push(libro)

                    setLibros([])
                    setLibros((anterior) => [...anterior, libro])
                }

            },
            allowOutsideClick: () => !Swal.isLoading()

        }).then((result) => {
            setA_Busqueda("")
        })
    }

    const eliminarLibro = (id) => {
        let listalibros = libros.filter(p => p.idLibro != id)
        setLibros(listalibros)
    }

    const registroPrestamo = () => {

        if (libros.length < 1) {
            Swal.fire(
                'Opps!',
                'No existen libros',
                'error'
            )
            return
        }

        let prestamo = {
            documentoCliente: documentoCliente,
            nombreCliente: nombreCliente,
            tipoDocumento: tipoDocumento,
            idUsuario: JSON.parse(user).idUsuario,
            listaLibros: libros
        }

        const api = fetch(urlPrestamoRegistrar, {  
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(prestamo)
        })
        .then((response) => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then((dataJson) => {
            reestablecer();
            var data = dataJson;
            Swal.fire(
                'Prestamo registrado!',
                'Folio de registro: ' + data.numeroDocumento,
                'success'
            )

        }).catch((error) => {
            Swal.fire(
                'Error!',
                'No se pudo crear el registro',
                'error'
            )
            console.log("No se pudo registar ", error)
        })

    }

    return (
        <Row>
            <Col sm={8}>

                <Row className="mb-2">
                    <Col sm={12}>
                        <Card>
                            <CardHeader style={{ backgroundColor: '#4e73df', color: "white" }}>
                                Registrar prestamo
                            </CardHeader>
                            <CardBody>
                                <Row>
                                    <Col sm={6}>
                                        <FormGroup>
                                            <Label>Datos del documento de identificacion</Label>
                                            <Input bsSize="sm" value={documentoCliente} onChange={ (e) => setDocumentoCliente(e.target.value)} />
                                        </FormGroup>
                                    </Col>
                                    <Col sm={6}>
                                        <FormGroup>
                                            <Label>Nombre y apellidos del solicitante</Label>
                                            <Input bsSize="sm" value={nombreCliente} onChange={(e) => setNombreCliente(e.target.value)}/>
                                        </FormGroup>
                                    </Col>
                                </Row>
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        <Card>
                            <CardHeader style={{ backgroundColor: '#4e73df', color: "white" }}>
                                Libro requerido
                            </CardHeader>
                            <CardBody>
                                <Row className="mb-2">
                                    <Col sm={12}>
                                        <FormGroup>
                                            <Autosuggest
                                                suggestions={a_Libros}
                                                onSuggestionsFetchRequested={onSuggestionsFetchRequested}
                                                onSuggestionsClearRequested={onSuggestionsClearRequested}
                                                getSuggestionValue={getSuggestionValue}
                                                renderSuggestion={renderSuggestion}
                                                inputProps={inputProps}
                                                onSuggestionSelected={sugerenciaSeleccionada}
                                            />
                                        </FormGroup>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col sm={12}>
                                        <Table striped size="sm">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>Libro</th>
                                                    <th>Cantidad</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {
                                                    (libros.length < 1) ? (
                                                        <tr>
                                                            <td colSpan="5">Sin libros</td>
                                                        </tr>
                                                    ) :
                                                    (
                                                        libros.map((item) => (
                                                            <tr key={item.idLibro}>
                                                                <td>
                                                                    <Button color="danger" size="sm"
                                                                        onClick={() => eliminarLibro(item.idLibro)}
                                                                    >
                                                                        <i className="fas fa-trash-alt"></i>
                                                                    </Button>
                                                                </td>
                                                                <td>{item.descripcion}</td>
                                                                <td>{item.cantidad}</td>
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
            </Col>

            <Col sm={4}>
                <Row className="mb-2">
                    <Col sm={12}>
                        <Card>
                            <CardHeader style={{ backgroundColor: '#4e73df', color: "white" }}>
                                Detalle identificacion
                            </CardHeader>
                            <CardBody>
                                <Row className="mb-2">
                                    <Col sm={12}>
                                        <InputGroup size="sm" >
                                            <InputGroupText>Tipo:</InputGroupText>
                                            <Input type="select" value={tipoDocumento} onChange={ (e) => setTipoDocumento(e.target.value)}>
                                                <option value="INE">INE</option>
                                                <option value="Credencial Escolar">Credencial Escolar</option>
                                            </Input>
                                        </InputGroup>
                                    </Col>
                                </Row>

                                
                                
                                
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12}>
                        <Card>
                            <CardBody>
                                <Button color="primary" block onClick={registroPrestamo} >
                                    <i className="fas fa-money-check"></i> Registrar prestamo</Button>
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </Col>
        </Row>
    )
}

export default Prestamo;