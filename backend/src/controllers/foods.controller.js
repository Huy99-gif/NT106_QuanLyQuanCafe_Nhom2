const { db } = require('../config/firebase');
const { info } = require('../utils/logger');

/** ID tiếp theo = max(số trong mon_XXX) + 1 — không cần reorder cả node sau mỗi lần xóa */
function computeNextFoodId(existingVal) {
    if (!existingVal || typeof existingVal !== 'object') return 'mon_001';
    const prefix = 'mon_';
    let max = 0;
    for (const key of Object.keys(existingVal)) {
        if (!key.startsWith(prefix)) continue;
        const n = parseInt(key.slice(prefix.length), 10);
        if (!Number.isNaN(n) && n > max) max = n;
    }
    return `${prefix}${(max + 1).toString().padStart(3, '0')}`;
}

exports.getAll = async (req, res, next) => {
    try {
        const snapshot = await db.ref('mon_uong').once('value');
        res.status(200).json(snapshot.val() || {});
    } catch (err) {
        next(err);
    }
};

exports.add = async (req, res, next) => {
    try {
        const foodData = req.body;
        const snapshot = await db.ref('mon_uong').once('value');
        const nextId = computeNextFoodId(snapshot.val());

        await db.ref(`mon_uong/${nextId}`).set(foodData);
        info('Food added', { foodId: nextId });
        res.status(201).json({ success: true, foodId: nextId });
    } catch (err) {
        next(err);
    }
};

exports.update = async (req, res, next) => {
    try {
        const { id } = req.params;
        const updateData = req.body;
        delete updateData.Id;

        await db.ref(`mon_uong/${id}`).update(updateData);
        info('Food updated', { foodId: id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};

exports.remove = async (req, res, next) => {
    try {
        const { id } = req.params;
        await db.ref(`mon_uong/${id}`).remove();
        info('Food deleted', { foodId: id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};
