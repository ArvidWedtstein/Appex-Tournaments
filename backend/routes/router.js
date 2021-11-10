const express = require("express");
const router = express.Router();
const controller = require("../controllers/routeController");

router.get("/gettournaments", controller.gettournaments);
router.post("/newtournament", controller.newtournament);
module.exports = router;