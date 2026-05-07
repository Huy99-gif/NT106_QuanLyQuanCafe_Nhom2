const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyAndGetUser } = require("../../middlewares/auth_middleware");

/**
 * API: get_history
 */
exports.getChatHistory = onRequest(async (req, res) => {
    if (req.method !== "GET") return res.status(405).send({ message: "Method Not Allowed" });
    const { roomId } = req.query;
    try {
        await verifyAndGetUser(req);
        const snapshot = await db.ref(`tin_nhan/${roomId}`).once("value");
        const history = [];
        snapshot.forEach((child) => {
            const val = child.val();
            if (val && typeof val === "object" && !Array.isArray(val)) {
                history.push(val);
            }
        });
        history.sort((a, b) => {
            const ta = Number(a.thoi_gian ?? a.timestamp ?? 0);
            const tb = Number(b.thoi_gian ?? b.timestamp ?? 0);
            return ta - tb;
        });
        return res.status(200).send(history);
    } catch (error) {
        return res.status(500).send({ error: error.message });
    }
});
