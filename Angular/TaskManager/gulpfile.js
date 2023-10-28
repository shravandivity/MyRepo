var gulp = require("gulp");
gulp.task("Copy-dist-to-wwwroot",()=>{
    return gulp.src("./dist/task-manager/**/*")
    .pipe(gulp.dest("/Users/shravandivity/Projects/MyRepo/TaskManagerAPI/taskmanagermvc/wwwroot"));
});
gulp.task("default",()=>{
    gulp.watch("./dist/task-manager",gulp.series("Copy-dist-to-wwwroot"));
});