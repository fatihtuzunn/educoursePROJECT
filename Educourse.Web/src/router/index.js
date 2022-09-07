import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  scrollBehavior() {
    return { x: 0, y: 0 };
  },
  routes: [
    {
      path: "/",
      name: "home",
      component: () => import("@/views/Home.vue"),
      meta: {
        pageTitle: "Home",
        breadcrumb: [
          {
            text: "Home",
            active: true,
          },
        ],
      },
    },
    {
      path: "/lessons",
      name: "lessons",
      component: () => import("@/views/SecondPage.vue"),
      
    },
    {
      path: "/lessons/:lessonId",
      name: "lessons/:lessonId",
      component: () => import("@/views/Video.vue"),
      meta: {
        pageTitle: "Lesson Video Page",
        breadcrumb: [
          {
            text: "Lesson Video Page",
            active: true,
          },
        ],
      },
    },
    {
      path: "/login",
      name: "login",
      component: () => import("@/views/Login.vue"),
      meta: {
        layout: "full",
      },
    },
    {
      path: "/register",
      name: "register",
      component: () => import("@/views/Register.vue"),
      meta: {
        layout: "full",
      },
    },
    {
      path: "/test-page",
      name: "test-page",
      component: () => import("@/views/Test.vue"),
    },

    {
      path: "/error-404",
      name: "error-404",
      component: () => import("@/views/error/Error404.vue"),
      meta: {
        layout: "full",
      },
    },
    {
      path: "*",
      redirect: "error-404",
    },
  ],
});

// auth
router.beforeEach((to, from, next) => {
  const publicPages = ["/login", "/register"];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem("token");

  if (authRequired && !loggedIn) {
    next("/login");
  } else {
    next();
  }
  
});

// ? For splash screen
// Remove afterEach hook if you are not using splash screen
router.afterEach(() => {
  // Remove initial loading
  const appLoading = document.getElementById("loading-bg");
  if (appLoading) {
    appLoading.style.display = "none";
  }
});

export default router;
