/*
    Definición de tabla Clientes y algunos registros iniciales
    Autor: Diana Sánchez
    Fecha creación: 13/09/2025
*/

-- Estructura de la tabla

CREATE TABLE Clientes (
    codigo_cliente INTEGER PRIMARY KEY AUTOINCREMENT,
    primer_nombre TEXT NOT NULL,
    segundo_nombre TEXT,
    primer_apellido TEXT NOT NULL,
    segundo_apellido TEXT,
    fecha_nacimiento TEXT NOT NULL,
    sexo_cliente TEXT NOT NULL,
    ingresos_cliente REAL NOT NULL,
    fecha_creacion TEXT DEFAULT (date('now')),
    estado_cliente TEXT NOT NULL
);

-- Registros iniciales

INSERT INTO Clientes (
    primer_nombre,
    segundo_nombre,
    primer_apellido,
    segundo_apellido,
    fecha_nacimiento,
    sexo_cliente,
    ingresos_cliente,
    estado_cliente
) VALUES (
    'Sebastián',
    'Lissandro',
    'Cárcamo',
    'Hernández',
    '1990-05-12',
    'M',
    10500,
    'A'
);

INSERT INTO Clientes (
    primer_nombre,
    segundo_nombre,
    primer_apellido,
    segundo_apellido,
    fecha_nacimiento,
    sexo_cliente,
    ingresos_cliente,
    estado_cliente
) VALUES (
    'Oscar',
    'Emilio',
    'Cáceres',
    'Vásquez',
    '1997-10-10',
    'M',
    15000,
    'A'
);

INSERT INTO Clientes (
    primer_nombre,
    segundo_nombre,
    primer_apellido,
    segundo_apellido,
    fecha_nacimiento,
    sexo_cliente,
    ingresos_cliente,
    estado_cliente
) VALUES (
    'Mónica',
    'Liliana',
    'Cárcamo',
    'Sevilla',
    '1999-09-01',
    'F',
    18000,
    'A'
);

INSERT INTO Clientes (
    primer_nombre,
    segundo_nombre,
    primer_apellido,
    segundo_apellido,
    fecha_nacimiento,
    sexo_cliente,
    ingresos_cliente,
    estado_cliente
) VALUES (
    'Ana',
    'Raquel',
    'Gómez',
    'Rodríguez',
    '2000-05-05',
    'F',
    20500,
    'A'
);

INSERT INTO Clientes (
    primer_nombre,
    segundo_nombre,
    primer_apellido,
    segundo_apellido,
    fecha_nacimiento,
    sexo_cliente,
    ingresos_cliente,
    estado_cliente
) VALUES (
    'Lucas',
    'Mateo',
    'Valeriano',
    'Canales',
    '1993-12-12',
    'M',
    38000,
    'A'
);

/*
    Definición de la tabla Cuentas
    Autor: Diana Sánchez
    Fecha creación: 13/09/2025
*/

CREATE TABLE Cuentas (
    codigo_cuenta INTEGER PRIMARY KEY AUTOINCREMENT,
    codigo_cliente INTEGER NOT NULL,
    saldo_cuenta REAL NOT NULL,
    estado_cuenta TEXT NOT NULL,
    FOREIGN KEY (codigo_cliente) REFERENCES Clientes(codigo_cliente)
);

/*
    Definición de la tabla Transacciones
    Autor: Diana Sánchez
    Fecha creación: 13/09/2025
*/

CREATE TABLE Transacciones (
   codigo_transaccion INTEGER PRIMARY KEY AUTOINCREMENT,
   codigo_cuenta INTEGER NOT NULL,
   tipo_transaccion TEXT NOT NULL,
   fecha_transaccion TEXT DEFAULT (date('now')),
   monto_transaccion REAL NOT NULL,
   FOREIGN KEY (codigo_cuenta) REFERENCES Cuentas(codigo_cuenta)
);


