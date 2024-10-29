CREATE TRIGGER trg_generar_numero_turno
ON TurnosPreventa
AFTER INSERT
AS
BEGIN
    UPDATE TurnosPreventa
    SET numero_turno = CONCAT('T-', RIGHT('00000' + CAST(INSERTED.id AS VARCHAR), 5))
    FROM INSERTED
    WHERE TurnosPreventa.id = INSERTED.id;
END;
