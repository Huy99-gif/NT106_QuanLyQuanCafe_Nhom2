const { onRequest } = require("firebase-functions/v2/https");

const { db } = require("../../config/firebase");

const { verifyManagerRole } = require("../../middlewares/auth_middleware");



/**

 * API: delete_food

 */

exports.deleteFood = onRequest(async (req, res) => {

    if (req.method !== "POST") return res.status(405).send("Method Not Allowed");

    try {

        await verifyManagerRole(req);

        const { foodId } = req.body;



        await db.ref(`mon_uong/${foodId}`).remove();



        return res.status(200).send({ success: true });

    } catch (error) {

        return res.status(500).send({ error: error.message });

    }

});

