
     /**-------------------${tablecomment}----BEGIN-------------------**/

    //菜单权限
    public static final String ${tablename?upper_case}_MENU = "${tablename?replace('_','.')}.info";
    //新增
    public static final String ${tablename?upper_case}_ADD = "${tablename?replace('_','.')}.add";
    //修改
    public static final String ${tablename?upper_case}_UPDATE = "${tablename?replace('_','.')}.update";
    //修改
    public static final String ${tablename?upper_case}_Detail = "${tablename?replace('_','.')}.detail";
    //删除
    public static final String ${tablename?upper_case}_DELETE = "${tablename?replace('_','.')}.delete";

    public String get${tablename?upper_case}_MENU() {
        return ${tablename?upper_case}_MENU;
    }
    public String get${tablename?upper_case}_ADD() {
        return ${tablename?upper_case}_ADD;
    }
    public String get${tablename?upper_case}_UPDATE() {
        return ${tablename?upper_case}_UPDATE;
    }
    public String get${tablename?upper_case}_DELETE() {
        return ${tablename?upper_case}_DELETE;
    }
    public String get${tablename?upper_case}_DETAIL() {
        return ${tablename?upper_case}_DETAIL;
    }
    /**-------------------${tablecomment}----END-------------------**/