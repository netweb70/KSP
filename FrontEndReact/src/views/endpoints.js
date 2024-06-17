const baseURL = process.env.REACT_APP_API_URL;

export const urlLogin = `${baseURL}/api/Session/Login`;
export const urlRol = `${baseURL}/api/Rol/Lista`;
export const urlUsuarioLista = `${baseURL}/api/Usuario/Lista`;
export const urlUsuarioGuardar = `${baseURL}/api/Usuario/Guardar`;
export const urlUsuarioEditar = `${baseURL}/api/Usuario/Editar`;
export const urlUsuarioEliminar = `${baseURL}/api/Usuario/Eliminar`;

export const urlCategoriaLista = `${baseURL}/api/Categoria/Lista`;
export const urlCategoriaGuardar = `${baseURL}/api/Categoria/Guardar`;
export const urlCategoriaEditar = `${baseURL}/api/Categoria/Editar`;
export const urlCategoriaEliminar = `${baseURL}/api/Categoria/Eliminar`;

export const urlLibroLista = `${baseURL}/api/Libro/Lista`;
export const urlLibroGuardar = `${baseURL}/api/Libro/Guardar`;
export const urlLibroEditar = `${baseURL}/api/Libro/Editar`;
export const urlLibroEliminar = `${baseURL}/api/Libro/Eliminar`;

export const urlPrestamoLibros = `${baseURL}/api/Prestamo/Libros`;
export const urlPrestamoRegistrar = `${baseURL}/api/Prestamo/Registrar`;
export const urlPrestamoListar = `${baseURL}/api/Prestamo/Listar`;

export const urlPrestamoRegistrarDevolucion = `${baseURL}/api/Prestamo/RegistrarDevolucion`;



