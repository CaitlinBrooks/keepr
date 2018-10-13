(function (e) { function t(t) { for (var r, o, i = t[0], l = t[1], u = t[2], c = 0, d = []; c < i.length; c++)o = i[c], a[o] && d.push(a[o][0]), a[o] = 0; for (r in l) Object.prototype.hasOwnProperty.call(l, r) && (e[r] = l[r]); p && p(t); while (d.length) d.shift()(); return n.push.apply(n, u || []), s() } function s() { for (var e, t = 0; t < n.length; t++) { for (var s = n[t], r = !0, i = 1; i < s.length; i++) { var l = s[i]; 0 !== a[l] && (r = !1) } r && (n.splice(t--, 1), e = o(o.s = s[0])) } return e } var r = {}, a = { app: 0 }, n = []; function o(t) { if (r[t]) return r[t].exports; var s = r[t] = { i: t, l: !1, exports: {} }; return e[t].call(s.exports, s, s.exports, o), s.l = !0, s.exports } o.m = e, o.c = r, o.d = function (e, t, s) { o.o(e, t) || Object.defineProperty(e, t, { enumerable: !0, get: s }) }, o.r = function (e) { "undefined" !== typeof Symbol && Symbol.toStringTag && Object.defineProperty(e, Symbol.toStringTag, { value: "Module" }), Object.defineProperty(e, "__esModule", { value: !0 }) }, o.t = function (e, t) { if (1 & t && (e = o(e)), 8 & t) return e; if (4 & t && "object" === typeof e && e && e.__esModule) return e; var s = Object.create(null); if (o.r(s), Object.defineProperty(s, "default", { enumerable: !0, value: e }), 2 & t && "string" != typeof e) for (var r in e) o.d(s, r, function (t) { return e[t] }.bind(null, r)); return s }, o.n = function (e) { var t = e && e.__esModule ? function () { return e["default"] } : function () { return e }; return o.d(t, "a", t), t }, o.o = function (e, t) { return Object.prototype.hasOwnProperty.call(e, t) }, o.p = "/"; var i = window["webpackJsonp"] = window["webpackJsonp"] || [], l = i.push.bind(i); i.push = t, i = i.slice(); for (var u = 0; u < i.length; u++)t(i[u]); var p = l; n.push([0, "chunk-vendors"]), s() })({ 0: function (e, t, s) { e.exports = s("56d7") }, "034f": function (e, t, s) { "use strict"; var r = s("c21b"), a = s.n(r); a.a }, "046d": function (e, t, s) { "use strict"; var r = s("40f0"), a = s.n(r); a.a }, "40f0": function (e, t, s) { }, "56d7": function (e, t, s) { "use strict"; s.r(t); var r = s("2b0e"), a = function () { var e = this, t = e.$createElement, s = e._self._c || t; return s("div", { attrs: { id: "app" } }, [s("router-view")], 1) }, n = [], o = (s("034f"), s("2877")), i = {}, l = Object(o["a"])(i, a, n, !1, null, null, null); l.options.__file = "App.vue"; var u = l.exports, p = s("8c4f"), c = function () { var e = this, t = e.$createElement, s = e._self._c || t; return s("div", { staticClass: "home" }, [s("h1", [e._v("Dashboard")]), s("UserKeeps"), s("UserVaults"), s("button", { on: { click: e.logout } }, [e._v("Logout")])], 1) }, d = [], m = function () { var e = this, t = e.$createElement, s = e._self._c || t; return s("div", { staticClass: "userKeeps" }, [s("h1", [e._v("Your Keeps")]), e._l(e.keepsById, function (t) { return s("div", { key: e.keepsById.id }, [s("img", { staticClass: "keepCard", staticStyle: { width: "200px", height: "200px" }, attrs: { src: t.img, alt: "keep.name" } })]) })], 2) }, h = [], v = { name: "userKeeps", computed: { keepsById() { return this.$store.state.keepsById } } }, g = v, f = (s("9e9b"), Object(o["a"])(g, m, h, !1, null, null, null)); f.options.__file = "UserKeeps.vue"; var w = f.exports, _ = function () { var e = this, t = e.$createElement, s = e._self._c || t; return s("div", { staticClass: "userVaults" }, [s("h1", [e._v("Your Vaults")]), e._l(e.vaultsById, function (t) { return s("div", { key: e.vaultsById.id }, [s("img", { staticClass: "keepCard", attrs: { src: e.keep.img, alt: "vault.name" } }), s("p", [e._v("Title: " + e._s(e.vaultsById.name))])]) })], 2) }, b = [], y = { name: "userVaults", computed: { vaultsById() { return this.$store.state.vaults } }, components: {} }, k = y, U = (s("cb0d"), Object(o["a"])(k, _, b, !1, null, null, null)); U.options.__file = "UserVaults.vue"; var $ = U.exports, K = { name: "home", computed: { user() { return this.$store.state.user } }, components: { UserKeeps: w, UserVaults: $ }, mounted() { this.$store.dispatch("getVaultsByUserId", this.user.id), this.$store.dispatch("getKeepsByUserId", this.user.id), this.$store.state.user.id || this.$router.push({ name: "login" }) }, methods: { logout() { this.$store.dispatch("logout") } } }, I = K, x = Object(o["a"])(I, c, d, !1, null, null, null); x.options.__file = "Home.vue"; var B = x.exports, C = function () { var e = this, t = e.$createElement, s = e._self._c || t; return s("div", { staticClass: "login" }, [e.loginForm ? s("form", { on: { submit: function (t) { return t.preventDefault(), e.loginUser(t) } } }, [s("input", { directives: [{ name: "model", rawName: "v-model", value: e.creds.email, expression: "creds.email" }], attrs: { type: "email", placeholder: "email" }, domProps: { value: e.creds.email }, on: { input: function (t) { t.target.composing || e.$set(e.creds, "email", t.target.value) } } }), s("input", { directives: [{ name: "model", rawName: "v-model", value: e.creds.password, expression: "creds.password" }], attrs: { type: "password", placeholder: "password" }, domProps: { value: e.creds.password }, on: { input: function (t) { t.target.composing || e.$set(e.creds, "password", t.target.value) } } }), s("button", { attrs: { type: "submit" } }, [e._v("Login")])]) : s("form", { on: { submit: function (t) { return t.preventDefault(), e.register(t) } } }, [s("input", { directives: [{ name: "model", rawName: "v-model", value: e.newUser.username, expression: "newUser.username" }], attrs: { type: "text", placeholder: "name" }, domProps: { value: e.newUser.username }, on: { input: function (t) { t.target.composing || e.$set(e.newUser, "username", t.target.value) } } }), s("input", { directives: [{ name: "model", rawName: "v-model", value: e.newUser.email, expression: "newUser.email" }], attrs: { type: "email", placeholder: "email" }, domProps: { value: e.newUser.email }, on: { input: function (t) { t.target.composing || e.$set(e.newUser, "email", t.target.value) } } }), s("input", { directives: [{ name: "model", rawName: "v-model", value: e.newUser.password, expression: "newUser.password" }], attrs: { type: "password", placeholder: "password" }, domProps: { value: e.newUser.password }, on: { input: function (t) { t.target.composing || e.$set(e.newUser, "password", t.target.value) } } }), s("button", { attrs: { type: "submit" } }, [e._v("Create Account")])]), s("div", { on: { click: function (t) { e.loginForm = !e.loginForm } } }, [e.loginForm ? s("p", [e._v("No Account? Click to Register")]) : s("p", [e._v("Already have an account? Click to Login")])]), s("keeps")], 1) }, O = [], V = function () { var e = this, t = e.$createElement, s = e._self._c || t; return s("div", { staticClass: "publicKeeps" }, [s("h1", [e._v("Public Keeps")]), e._l(e.keeps, function (t) { return s("div", { key: t.id, staticClass: "row" }, [s("div", { staticClass: "col-12" }, [0 == t.isPrivate ? s("div", { staticClass: "keepCard" }, [s("img", { staticClass: "keepCard", staticStyle: { width: "200px", height: "200px" }, attrs: { src: t.img, alt: "keep.name" } })]) : e._e()])]) })], 2) }, j = [], P = { computed: { keeps() { return this.$store.state.keeps } } }, S = P, E = (s("046d"), Object(o["a"])(S, V, j, !1, null, null, null)); E.options.__file = "Keeps.vue"; var L = E.exports, A = { name: "login", mounted() { this.$store.dispatch("authenticate") }, data() { return { loginForm: !0, creds: { email: "", password: "" }, newUser: { email: "", password: "", username: "" } } }, methods: { register() { this.$store.dispatch("register", this.newUser) }, loginUser() { this.$store.dispatch("login", this.creds) } }, mounted() { this.$store.dispatch("getAllKeeps") }, components: { Keeps: L } }, F = A, N = Object(o["a"])(F, C, O, !1, null, null, null); N.options.__file = "Login.vue"; var M = N.exports, T = function () { var e = this, t = e.$createElement, s = e._self._c || t; return s("div", { staticClass: "vaultKeeps" }, [s("h1", [e._v("Welcome " + e._s(e.user.username) + "!")])]) }, D = [], R = { name: "vaultKeeps", computed: { user() { return this.$store.state.user }, components() { }, mounted() { this.$store.dispatch("getVaultsById", this.$store.state.user.id), this.$store.dispatch("getKeepsById", this.$store.state.user.id), this.$store.state.user.id || this.$router.push({ name: "login" }) } } }, J = R, Y = Object(o["a"])(J, T, D, !1, null, null, null); Y.options.__file = "VaultKeeps.vue"; var H = Y.exports; r["a"].use(p["a"]); var W = new p["a"]({ routes: [{ path: "/", name: "home", component: B }, { path: "/login", name: "login", component: M }, { path: "/", name: "vaultkeeps", component: H }] }), q = s("2f62"), z = s("bc3a"), G = s.n(z); r["a"].use(q["a"]); let Q = G.a.create({ baseURL: "http://localhost:5000/account/", timeout: 3e3, withCredentials: !0 }), X = G.a.create({ baseURL: "http://localhost:5000/api/", timeout: 3e3, withCredentials: !0 }); var Z = new q["a"].Store({ state: { user: {}, keeps: [], vaults: [], keepsById: [], vaultkeeps: [] }, mutations: { setVaultById(e, t) { e.keeps = t }, setKeepsByUserId(e, t) { e.keepsById = t }, setKeeps(e, t) { e.keeps = t }, setVaults(e, t) { e.vaults = t }, setVaultKeeps(e, t) { e.vaultkeeps = t }, setUser(e, t) { e.user = t } }, actions: { register({ commit: e, dispatch: t }, s) { Q.post("register", s).then(t => { e("setUser", t.data), W.push({ name: "home" }) }).catch(e => { console.log("[registration failed] :", e) }) }, authenticate({ commit: e, dispatch: t }) { Q.get("authenticate").then(t => { e("setUser", t.data), W.push({ name: "home" }) }).catch(e => { console.log("not authenticated") }) }, login({ commit: e, dispatch: t }, s) { Q.post("login", s).then(t => { e("setUser", t.data), W.push({ name: "home" }) }).catch(e => { console.log("Login Failed") }) }, logout({ commit: e, dispatch: t }) { Q.delete("logout").then(e => { W.push({ name: "login" }) }) }, newKeep({ commit: e, dispatch: t }, s) { X.post("keeps", s).then(t => { e("") }).catch(e => { console.log("Unable to create keep") }) }, deleteKeep({ dispatch: e }, t) { X.post("keeps", t).then(s => { e("getKeepById", t.userId) }) }, getKeepsByUserId({ commit: e }, t) { X.get("keeps/" + t).then(t => { e("setKeepsByUserId", t.data) }) }, newVault({ commit: e, dispatch: t }, s) { Q.post("", s).then(t => { e("") }).catch(e => { console.log("Unable to create vault") }) }, deleteVault({ dispatch: e }, t) { X.post("keeps", t).then(s => { e("getKeepById", t.userId) }) }, getVaultsId({ commit: e }, t) { X.get("vaults").then(t => { e("setVaultById", t.data) }) }, getAllKeeps({ commit: e, dispatch: t }) { X.get("keeps").then(t => { e("setKeeps", t.data) }) } } }); r["a"].config.productionTip = !1, new r["a"]({ router: W, store: Z, created() { this.$store.dispatch("authenticate") }, render: e => e(u) }).$mount("#app") }, "80b2": function (e, t, s) { }, "9e9b": function (e, t, s) { "use strict"; var r = s("e5b3"), a = s.n(r); a.a }, c21b: function (e, t, s) { }, cb0d: function (e, t, s) { "use strict"; var r = s("80b2"), a = s.n(r); a.a }, e5b3: function (e, t, s) { } });
//# sourceMappingURL=app.a9847e28.js.map