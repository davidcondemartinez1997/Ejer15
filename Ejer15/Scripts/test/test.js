describe("A suite", function () {
    it("contains spec with an expectation", function () {
        expect(true).toBe(true);
    });
});

describe("Tests de prueba GET", function () {
    var res;

    it("prueba de peticion REST GET", function (done) {
        $.get("api/values/3", function (result) {
            res = result;
            done();
        });
    });

    afterEach(function (done) {
        expect(res).toBe("value");
        done();
    }, 1000);
});


describe("Tests de prueba GETALL", function () {
    var res;

    it("prueba de peticion REST GETALL", function (done) {
        $.get("api/values", function (result) {
            res = result;
            done();
        });
    });

    afterEach(function (done) {
        expect(typeof res).toBe("object");
        done();
    }, 1000);
});


describe("Tests de prueba POST", function () {
    var res;

    it("prueba de peticion REST POST", function (done) {
        $.post("api/values", null, function (result) {
            res = result;
            done();
        });
    });

    afterEach(function (done) {
        expect(true).toBe(true);
        done();
    }, 1000);
});

describe("Tests de prueba PUT", function () {
    var res;

    it("prueba de peticion REST PUT", function (done) {
        $.ajax(
            {
                url: "api/values/5",
                type: "PUT",
                success: function (result) {
                    res = result;
                    done();
                }
            }
        );
    });

    afterEach(function (done) {
        expect(true).toBe(true);
        done();
    }, 1000);
});

describe("Tests de prueba DELETE", function () {
    var res;

    it("prueba de peticion REST DELETE", function (done) {
        $.ajax(
             {
                 url: "api/values/5",
                 type: "DELETE",
                 success: function (result) {
                     res = result;
                     done();
                 }
             }
         );
    });

    afterEach(function (done) {
        expect(true).toBe(true);
        done();
    }, 1000);
});


describe("Tests de Entrada POST", function () {
    var res;
    
    it("prueba de peticion REST POST", function (done) {
        var params = {
            PRECIO: 3.4
        };
        $.post("api/Entradas", params, function (result) {
            res = result;
            done();
        });
    });

    afterEach(function (done) {
        expect(res.ID != undefined).toBe(true);
        done();
    }, 1000);
});

//Pasar un valor (precio) y que devuelva la entidad con un valor