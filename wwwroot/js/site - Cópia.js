function formToObject(form) {
    const formData = new FormData(form);
    const obj = {};

    formData.forEach((value, key) => {
        if (obj[key]) {
            // Se já existe uma chave, transforma em array para lidar com múltiplos inputs com o mesmo name
            obj[key] = Array.isArray(obj[key]) ? [...obj[key], value] : [obj[key], value];
        } else {
            obj[key] = value;
        }
    });

    return obj;
}